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
    public partial class EditerQuestionnaireForm : Form
    {
        Questionnaire Monquestionnaire = new Questionnaire();
        Question MesQuestions = new Question();
        private int questionnaireId;
        private BindingList<Thème> themeListe = new BindingList<Thème>();


        public EditerQuestionnaireForm(int id)
        {
            InitializeComponent();
            questionnaireId = id;
            chargerMonQuestionnaire(questionnaireId);
            //AfficherThemes();
        }

        private void EditerQuestionnaireForm_Load(object sender, EventArgs e)
        {
            chargerMonQuestionnaire(questionnaireId);

            //ChargerLesDonnees();
        }

        // Méthode pour charger les données du questionnaire

        public void chargerMonQuestionnaire(int id)
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
                    string query = "SELECT Id, Libelle, ThemeId FROM questionnaire WHERE id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Monquestionnaire.Libelle = reader.GetString("Libelle");
                                Monquestionnaire.Id = reader.GetInt32("Id");
                                txtboxQuestionnaire.Text = Monquestionnaire.Libelle;
                                Monquestionnaire.ThemeId = reader.GetInt32("ThemeId");
                            }
                            else
                            {
                                MessageBox.Show("problème avec chargerMonQuestionnaire");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération du questionnaire : {ex.Message}");
            }

            ThemeController.RemplirComboBox(cbBoxTheme);
            ThemeController.SelectionnerLigneComboBox(cbBoxTheme, id);
            QuestionController.RemplirDGVavecQuestions(DGVQuestion, questionnaireId);



        }

        public void SauvegarderQuestionnaire()
        {

        }






        private void DGVQuestion_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Gestion des clics de souris sur les cellules de la DataGridView
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {
                    DataGridViewCell c = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
                    c.ContextMenuStrip = cmsQuestion;

                    c.ContextMenuStrip.Items[0].Text = $"Ajouter une question";
                    c.ContextMenuStrip.Items[1].Text = $"Éditer {c.Value}";
                    c.ContextMenuStrip.Items[2].Text = $"Supprimer {c.Value}";
                    //c.ContextMenuStrip.Items[3].Text = $"Ajouter ";

                    c.ContextMenuStrip.Show(
                        this.Location.X + this.ClientRectangle.Location.X + ((DataGridView)sender).Location.X + e.X,
                        this.Location.Y + this.ClientRectangle.Location.Y + ((DataGridView)sender).Location.Y + e.Y
                    );
                }
            }

        }

        private void btnAnnuler_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSauvegarder_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Récupérer les nouvelles valeurs
                string nomQuestionnaire = txtboxQuestionnaire.Text.Trim();
                int themeId = (int)cbBoxTheme.SelectedValue;

                if (string.IsNullOrEmpty(nomQuestionnaire))
                {
                    MessageBox.Show("Le nom du questionnaire ne peut pas être vide.");
                    return;
                }

                // Mettre à jour les données dans la base de données
                var questionnaire = new Modèles.Questionnaire
                {
                    //id = questionnaireId,
                    //libelle = nomQuestionnaire,
                    // themeId = themeId
                };

                // QuestionnaireController.ModifierQuestionnaire(questionnaire);

                // Confirmer la mise à jour
                MessageBox.Show("Le questionnaire a été modifié avec succès.");
                //GQuestionnaire.RafraichirDataGrid();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement des modifications : {ex.Message}");
            }

        }
    }

}

