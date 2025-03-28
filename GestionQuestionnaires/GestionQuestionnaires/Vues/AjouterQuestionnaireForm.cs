using GestionQuestionnaires.Contrôleurs;
using GestionQuestionnaires.Modèles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionQuestionnaires
{
    public partial class AjouterQuestionnaireForm : Form
    {
        Questionnaire NouveauQuestionnaire = new Questionnaire();
        Question NouvelleQuestion = new Question();
        private BindingList<Question> listeQuestions = new BindingList<Question>();
        public AjouterQuestionnaireForm(int id)
        {
            InitializeComponent();
            ChargerThemes();
        }

        private void InitialiserDataGridView()
        {
            DGVQuestion.DataSource = listeQuestions;
            DGVQuestion.Columns["Id"].Visible = false;
            DGVQuestion.Columns["Libelle"].HeaderText = "Question";
        }

        private void ChargerThemes()
        {
            ThemeController.RemplirComboBox(cbBoxTheme);
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {

            try
            {
                // Récupération des valeurs du formulaire
                string nomQuestionnaire = txtboxQuestionnaire.Text.Trim();
                int themeId = (int)cbBoxTheme.SelectedValue;

                // Vérifications
                if (string.IsNullOrEmpty(nomQuestionnaire))
                {
                    MessageBox.Show("Le nom du questionnaire est obligatoire.");
                    return;
                }

                // Connexion à la base de données
                GQConnexion DBCon = new GQConnexion
                {
                    Server = "localhost",
                    DatabaseName = "gestionquestionnaire",
                    UserName = "root",
                    Password = Crypto.Decrypt("xHhoy9Gmtj6SXFZCpaR+0g==")
                };

                if (DBCon.IsConnect())
                {
                    string query = "INSERT INTO questionnaire (Libelle, ThemeId) VALUES (@Libelle, @ThemeId)";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Libelle", nomQuestionnaire);
                        cmd.Parameters.AddWithValue("@ThemeId", themeId);
                        cmd.ExecuteNonQuery(); // Exécute la requête
                    }

                    MessageBox.Show("Le questionnaire a été ajouté avec succès.");
                    this.Close(); // Ferme la fenêtre après ajout
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout : {ex.Message}");
            }
        }

        private void btnAjouterQuestion_Click(object sender, EventArgs e)
        {
            string nouvelleQuestion = txtQuestion.Text.Trim();

            if (!string.IsNullOrEmpty(nouvelleQuestion))
            {
                listeQuestions.Add(new Question { Libelle = nouvelleQuestion });
                txtQuestion.Clear();
            }
            else
            {
                MessageBox.Show("Veuillez entrer une question valide.");
            }
        }

        private void cbBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string typeSelectionne = cbBoxType.SelectedItem.ToString();

            // Cacher tous les groupes par défaut
            GBvraiFaux.Visible = false;
            GBListeValeur.Visible = false;
            panelQCM.Visible = false;

            // Activer uniquement les contrôles correspondant au type sélectionné
            if (typeSelectionne == "Vrai/Faux")
            {
                GBvraiFaux.Visible = true;
            }
            else if (typeSelectionne == "Liste de Valeurs")
            {
                GBListeValeur.Visible = true;
            }
            else if (typeSelectionne == "QCM")
            {
                panelQCM.Visible = true;
            }
        }


        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
