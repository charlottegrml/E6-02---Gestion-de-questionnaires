using GestionQuestionnaires.Contrôleurs;
using GestionQuestionnaires.Modèles;
using GestionQuestionnaires.Utilitaires;
using GestionQuestionnaires.Vues;
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
        public AjouterQuestionnaireForm()
        {
            InitializeComponent();
            ChargerThemes();
        }

        private void ChargerThemes()
        {
            ThemeController.RemplirComboBox(cbBoxTheme);
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            string nomQuestionnaire = txtboxQuestionnaire.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomQuestionnaire))
            {
                MessageBox.Show("Veuillez saisir un nom pour le questionnaire.");
                return;
            }

            if (cbBoxTheme.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un thème.");
                return;
            }

            int themeId = (int)cbBoxTheme.SelectedValue;

            try
            {
                GQConnexion dbCon = new GQConnexion
                {
                    Server = "localhost",
                    DatabaseName = "gestionquestionnaire",
                    UserName = "root",
                    Password = Crypto.Decrypt("xHhoy9Gmtj6SXFZCpaR+0g==")
                };

                if (dbCon.IsConnect())
                {
                    int idQuestionnaire;

                    string insertQuery = "INSERT INTO questionnaire (Libelle, ThemeId) VALUES (@Libelle, @ThemeId)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, dbCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Libelle", nomQuestionnaire);
                        cmd.Parameters.AddWithValue("@ThemeId", themeId);
                        cmd.ExecuteNonQuery();
                        idQuestionnaire = (int)cmd.LastInsertedId;
                    }

                    MessageBox.Show("Questionnaire créé avec succès !");

                    // Ouvrir la fenêtre d’ajout de questions
                    AjouterQuestion formQuestion = new AjouterQuestion(idQuestionnaire);
                    formQuestion.Show();

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Connexion à la base de données impossible.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GQuestionnaire mainForm = new GQuestionnaire();
            mainForm.Show();
        }
    }
}
