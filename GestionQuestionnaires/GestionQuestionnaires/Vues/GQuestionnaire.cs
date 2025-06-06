using GestionQuestionnaires.Contrôleurs;
using GestionQuestionnaires.Modèles;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Tls;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;
using System.Diagnostics;

namespace GestionQuestionnaires
{
    public partial class GQuestionnaire : Form
    {
        private BindingList<Questionnaire> questionnaireListe = new BindingList<Questionnaire>();
        private BindingList<Theme> themeListe = new BindingList<Theme>();

        public GQuestionnaire()
        {
            InitializeComponent();
            this.Load += chargerLesDonnes;
        }

        // Méthode pour charger les données dans le DataGridView
        public void chargerLesDonnes(object sender, EventArgs e)
        {
            try
            {
                // Effacer les anciennes données
                questionnaireListe.Clear();
                questionnaireListe = new BindingList<Questionnaire>(Modèles.Questionnaire.GetQuestionnairesAvecThemes());

                themeListe.Clear();
                themeListe = new BindingList<Theme>(Modèles.Theme.GetThemes());

                // Sélectionner la ligne entière dans la DataGridView
                DGV1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGV1.MultiSelect = false;

                // Affecter la source des données à la DataGridView
                AffecterDonnees();

                // Ajouter la colonne "Thème"
                //AfficherColonneTheme();

                // Ajouter la colonne "NbQuestions"
                AfficherColonneNBQuestion();

                DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Remplir les colonnes "Thème" et "NbQuestions"
                RemplirThemeetNBQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Gestion des clics de souris sur les cellules de la DataGridView
        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {
                    DataGridViewCell c = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
                    c.ContextMenuStrip = cMS1;

                    c.ContextMenuStrip.Items[0].Text = $"Ajouter un questionnaire";
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

        private void cMS1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DataGridViewRow Ligne = DGV1.SelectedRows[0];

            int questionnaireId = (int)Ligne.Cells[0].Value;
            switch (e.ClickedItem.Text)
            {
                case string modifier when modifier.StartsWith("Éditer"):
                    EditerQuestionnaire(questionnaireId);
                    this.Close();
                    break;
                case string supprimer when supprimer.StartsWith("Supprimer"):
                    SupprimerQuestionnaire(questionnaireId);
                    break;
                case string ajouter when ajouter.StartsWith("Ajouter"):
                    ajouterQuestionnaire(questionnaireId);
                    break;
            }
        }

        public void ajouterQuestionnaire(int id)
        {
            var ajouterForm = new AjouterQuestionnaireForm();
            ajouterForm.ShowDialog();
            this.Close();
        }

        private void EditerQuestionnaire(int id)
        {
            var ModifierForm = new EditerQuestionnaireForm(id, this); // Passer l'id pour éditer le bon questionnaire
            ModifierForm.ShowDialog();
            //this.Close();
            //RafraichirDataGrid();
        }

        private void SupprimerQuestionnaire(int id)
        {
            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce questionnaire ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                QuestionnaireController.SupprimerQuestionnaire(id);
                chargerLesDonnes(null, null);
                this.Hide();
                GQuestionnaire mainForm = new GQuestionnaire();
                mainForm.Show();
            }
        }

        public void RafraichirDataGrid()
        {
            //var DGV = new List<int>();

            DGV1.DataSource = null;
            questionnaireListe.Clear();
            questionnaireListe = new BindingList<Questionnaire>(Modèles.Questionnaire.GetQuestionnairesAvecThemes());

            themeListe.Clear();
            themeListe = new BindingList<Theme>(Modèles.Theme.GetThemes());
            if (DGV1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = DGV1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = DGV1.Rows[selectedRowIndex];
                //Questionnaire selectedQuestionnaire = (Questionnaire)Row.DataBoundItem;
            }
            DGV1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV1.MultiSelect = false;


            AffecterDonnees();
            //AfficherColonneTheme();
            AfficherColonneNBQuestion();
            OrdreColonnes();

            DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            RemplirThemeetNBQuestion();

            OrdreColonnes();
        }


        //private void btnExporterPDF_Click(object sender, EventArgs e)
        //{
        //    ExporterQuestionnaireEnPDF();
        //}


        public void AffecterDonnees()
        {
            DGV1.DataSource = questionnaireListe;
            DGV1.Columns["libelle"].HeaderText = "Nom du questionnaire";
            DGV1.Columns["id"].Visible = false;
            DGV1.Columns["ThemeId"].Visible = false;
            DGV1.Columns["ThemeNom"].HeaderText = "Thème du questionnaire";

        }

        //public void AfficherColonneTheme()
        //{
        //    if (!DGV1.Columns.Contains("Thème"))
        //    {
        //        DataGridViewTextBoxColumn themeColumn = new DataGridViewTextBoxColumn
        //        {
        //            Name = "Thème",
        //            HeaderText = "Thème du questionnaire"
        //        };
        //        DGV1.Columns.Add(themeColumn);
        //    }
        //}

        public void AfficherColonneNBQuestion()
        {
            if (!DGV1.Columns.Contains("NbQuestions"))
            {
                DataGridViewTextBoxColumn questionCountColumn = new DataGridViewTextBoxColumn
                {
                    Name = "NbQuestions",
                    HeaderText = "Nombre de questions"
                };
                DGV1.Columns.Add(questionCountColumn);
            }
        }


        public void RemplirThemeetNBQuestion()
        {
            foreach (DataGridViewRow row in DGV1.Rows)
            {
                if (row.IsNewRow) continue;

                int questionnaireId = (int)row.Cells["id"].Value;

                // Associer un thème au questionnaire
                int themeId = (int)row.Cells["ThemeId"].Value;
                var theme = themeListe.FirstOrDefault(t => t.id == themeId);
                row.Cells["ThemeNom"].Value = theme?.nom;


                // Récupérer le nombre de questions
                var questions = QuestionController.ToutesLesQuestions(questionnaireId);
                row.Cells["NbQuestions"].Value = questions.Count;
            }
        }

        private void OrdreColonnes()
        {
            DGV1.Columns["id"].Visible = false;
            DGV1.Columns["libelle"].DisplayIndex = 0;
            DGV1.Columns["ThemeId"].DisplayIndex = 1;
            DGV1.Columns["NbQuestions"].DisplayIndex = 2;
        }

        


    }
}
