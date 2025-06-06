using GestionQuestionnaires.Contrôleurs;
using GestionQuestionnaires.Modèles;
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
    public partial class EditerQuestionnaireForm : Form
    {
        Questionnaire Monquestionnaire = new Questionnaire();
        Question MesQuestions = new Question();
        private int questionnaireId;
        private BindingList<Theme> themeListe = new BindingList<Theme>();


        private GQuestionnaire parentForm;

        public EditerQuestionnaireForm(int id, GQuestionnaire parent)
        {
            InitializeComponent();
            questionnaireId = id;
            parentForm = parent;
            chargerMonQuestionnaire(questionnaireId);
        }
        //private void EditerQuestionnaireForm_Load(object sender, EventArgs e)
        //{
        //    chargerMonQuestionnaire(questionnaireId);

        //    //ChargerLesDonnees();
        //}

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


            ThemeController.RemplirComboBoxAvecBonTheme(cbBoxTheme, Monquestionnaire.ThemeId);
            QuestionController.RemplirDGVavecQuestions(DGVQuestion, questionnaireId);


        }

        //public void SauvegarderQuestionnaire()
        //{

        //}


        public void RechargerQuestionnaire(int questionnaireId)
        {
            //questionnaireId = QuestionController.RetournerQuestionnaireIdByQuestion();
            chargerMonQuestionnaire(questionnaireId);
        }






        private void DGVQuestion_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
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

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GQuestionnaire mainForm = new GQuestionnaire();
            mainForm.Show();
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
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

                QuestionnaireController.ModifierQuestionnaire(questionnaireId, nomQuestionnaire, themeId);

                // Confirmer la mise à jour
                MessageBox.Show("Le questionnaire a été modifié avec succès.");
                this.Hide();
                GQuestionnaire mainForm = new GQuestionnaire();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement des modifications : {ex.Message}");
            }

        }

        private void cmsQuestion_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DataGridViewRow Ligne = DGVQuestion.SelectedRows[0];

            int questionId = (int)Ligne.Cells[0].Value;
            switch (e.ClickedItem.Text)
            {
                case string modifier when modifier.StartsWith("Éditer"):
                    EditerUneQuestion(questionId);
                    this.Close();
                    break;
                case string supprimer when supprimer.StartsWith("Supprimer"):
                    SupprimerQuestion(questionId);
                    break;
                case string ajouter when ajouter.StartsWith("Ajouter"):
                    ajouterQuestion(questionId);
                
                    break;
            }
        }

        public void ajouterQuestion(int id)
        {
            int idQuestionnaire = Monquestionnaire.Id;
            AjouterQuestion formQuestion = new AjouterQuestion(idQuestionnaire);
            formQuestion.Show();
        }

        private void EditerUneQuestion(int id)
        {
            var editerForm = new EditerQuestion(id, this);
            editerForm.ShowDialog(); 
            RechargerQuestionnaire(id);
        }

        private void SupprimerQuestion(int id)
        {
            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette question ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                QuestionController.SupprimerQuestion(id);
                chargerMonQuestionnaire(questionnaireId);
                this.Hide();
                EditerQuestionnaireForm mainForm = new EditerQuestionnaireForm(questionnaireId, parentForm);
                mainForm.Show();
            }
        }
    }






}



