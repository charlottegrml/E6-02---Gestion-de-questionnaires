using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using BCrypt.Net;
using GestionQuestionnaires.Modèles;

namespace GestionQuestionnaires
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // Vérifier si les champs sont valides
            if (champVide())
            {
                string username = txtboxUsername.Text.Trim();
                string password = txtboxPassword.Text.Trim();

                // Validation de l'utilisateur
                if (ValiderUtilisateur(username, password))
                {
                    // Si l'utilisateur est valide, cacher la fenêtre de login et afficher la fenêtre principale
                    this.Hide();
                    GQuestionnaire mainForm = new GQuestionnaire();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !");
                }
            }
        }

        // Vérification des champs vides
        public bool champVide()
        {
            star1.Visible = false;
            star2.Visible = false;
            if (txtboxPassword.Text.Trim().Equals("") && txtboxUsername.Text.Trim().Equals(""))
            {
                star1.Visible = true;
                star2.Visible = true;
                return false;
            }
            else if (txtboxUsername.Text.Trim().Equals(""))
            {
                star1.Visible = true;
                return false;
            }
            else if (txtboxPassword.Text.Trim().Equals(""))
            {
                star2.Visible = true;
                return false;
            }

            return true;
        }

        private bool ValiderUtilisateur(string nomUtilisateur, string motDePasse)
        {
            try
            {
                GQConnexion DBCon = new GQConnexion
                {
                    Server = "localhost",
                    DatabaseName = "gestionquestionnaire",
                    UserName = "root",
                    Password = Crypto.Decrypt("xHhoy9Gmtj6SXFZCpaR+0g==")
                };

                if (DBCon.IsConnect())
                {
                    string query = "SELECT id, nomUtilisateur, nom, prenom, motDePasse FROM utilisateurs WHERE nomUtilisateur = @nomUtilisateur";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@nomUtilisateur", nomUtilisateur);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string motDePasseHash = reader.GetString("motDePasse");

                                // Vérifie le mot de passe avec le hash
                                if (BCrypt.Net.BCrypt.Verify(motDePasse, motDePasseHash))
                                {
                                    // Stocker les infos utilisateur si besoin
                                    Utilitaires.UtilisateurConnecte.Id = reader.GetInt32("id");
                                    Utilitaires.UtilisateurConnecte.NomUtilisateur = reader.GetString("nomUtilisateur");
                                    Utilitaires.UtilisateurConnecte.Nom = reader.GetString("nom");
                                    Utilitaires.UtilisateurConnecte.Prenom = reader.GetString("prenom");

                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la validation de l'utilisateur : {ex.Message}");
            }

            return false;
        }



        private void btnPS_Click(object sender, EventArgs e)
        {

        }
    }
}
