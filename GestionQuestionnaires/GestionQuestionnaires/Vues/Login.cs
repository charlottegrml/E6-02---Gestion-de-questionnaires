using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

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
                var DBCon = new GQConnexion
                {
                    Server = "localhost",  
                    DatabaseName = "gestionquestionnaire", 
                    UserName = "root",  
                    Password = Crypto.Decrypt("xHhoy9Gmtj6SXFZCpaR+0g==") 
                };

                // Vérifier si la connexion à la base de données est réussie
                if (DBCon.IsConnect())
                {
                    string query = "SELECT COUNT(*) FROM utilisateurs WHERE nomUtilisateur = @nomUtilisateur AND motDePasse = @motDePasse";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@nomUtilisateur", nomUtilisateur);
                        cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int count = Convert.ToInt32(result);
                            return count > 0;
                        }
                        else
                        {
                            MessageBox.Show("Aucun utilisateur trouvé.");
                            return false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Erreur : Impossible de se connecter à la base de données.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion : {ex.Message}");
                return false;
            }
        }
    }
}
