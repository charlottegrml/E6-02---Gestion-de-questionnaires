using GestionQuestionnaires.Contrôleurs;
using GestionQuestionnaires.Modèles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionQuestionnaires.Vues
{
    public partial class AjouterQuestion : Form
    {
        private int _idQuestionnaire;


        public AjouterQuestion(int idQuestionnaire)
        {
            InitializeComponent();
            _idQuestionnaire = idQuestionnaire;

            gboxVF.Visible = false;
            gboxQCS.Visible = false;

            ChargerTypes();

            if (DGVReponses.Columns.Count == 0)
            {
                DGVReponses.Columns.Add("Libelle", "Libellé de la question");
                DGVReponses.Columns.Add("Valeur", "Valeur");
                DGVReponses.Columns.Add("Poids", "Poids");
                DGVReponses.Columns.Add("Correct", "Correcte ?");
            }

        }

        private void ChargerTypes()
        {
            TypeController.RemplirComboBox(cboxType);
        }

        private void cboxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Récupérer l’ID du type sélectionné
            int selectedTypeId = ((Types)cboxType.SelectedItem).id;


            // Afficher celle qui correspond
            if (selectedTypeId == 1)
            {
                gboxQCS.Visible = false;
                gboxVF.Visible = true;
                //MessageBox.Show("Type changé !");

            }
            else if (selectedTypeId == 3)
            {
                gboxQCS.Visible = true;
                gboxVF.Visible = false;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string libelleQuestion = txtboxLibelle.Text.Trim();
            if (string.IsNullOrEmpty(libelleQuestion))
            {
                MessageBox.Show("Veuillez saisir le libellé de la question.");
                return;
            }

            int selectedTypeId = ((Types)cboxType.SelectedItem).id;

            // Création de la question
            Question question = new Question
            {
                Libelle = libelleQuestion,
                QuestionnaireId = _idQuestionnaire,
                TypeId = selectedTypeId
            };

            int questionId = QuestionController.AjouterQuestionEtRetournerId(question);

            if (selectedTypeId == 1) // Vrai/Faux
            {
                if (!int.TryParse(txtPoidsVF.Text.Trim(), out int poids))
                {
                    MessageBox.Show("Le poids doit être un entier.");
                    return;
                }

                bool mauvaiseReponseNeg = checkBoxNeg.Checked;

                AjouterReponseVF(questionId, "Vrai", rbVrai.Checked, poids, mauvaiseReponseNeg);
                AjouterReponseVF(questionId, "Faux", rbFaux.Checked, poids, mauvaiseReponseNeg);
            }
            else if (selectedTypeId == 3) // QCS
            {
                if (DGVReponses.Rows.Count == 0)
                {
                    MessageBox.Show("Ajoutez au moins une réponse avant de sauvegarder la question.");
                    return;
                }

                foreach (DataGridViewRow row in DGVReponses.Rows)
                {
                    if (row.IsNewRow) continue; 
                    string valeur = row.Cells["Valeur"].Value?.ToString();
                    int poids = int.TryParse(row.Cells["Poids"].Value?.ToString(), out int p) ? p : 0;
                    bool correcte = row.Cells["Correct"].Value?.ToString() == "Oui";

                    Valeur v = new Valeur
                    {
                        Nom_Valeur = valeur,
                        QuestionId = questionId,
                        Correct = correcte,
                        Poids = poids
                    };

                    ValeurController.AjouterValeur(v);
                }
            }

            // Nettoyage pour la prochaine question
            txtboxLibelle.Clear();
            txtProposition.Clear();
            txtPoidsVF.Clear();
            txtPoidsQCS.Clear();
            checkBoxCorrecte.Checked = false;
            checkBoxNeg.Checked = false;
            rbVrai.Checked = false;
            rbFaux.Checked = false;
            DGVReponses.Rows.Clear();
        }


        private void AjouterReponseVF(int questionId, string nomValeur, bool estCorrecte, int poids, bool mauvaiseReponseNeg)
        {
            int poidsAUtiliser = estCorrecte ? poids : (mauvaiseReponseNeg ? -poids : 0);
            int correct = estCorrecte ? 1 : 0;

            // Ajout en base de données
            Valeur valeur = new Valeur
            {
                Nom_Valeur = nomValeur,
                QuestionId = questionId,
                Correct = estCorrecte,
                Poids = poidsAUtiliser
            };

            ValeurController.AjouterValeur(valeur); // Crée cette méthode

            // Ajout dans le DataGridView
            DGVReponses.Rows.Add(
                txtboxLibelle.Text,
                nomValeur,
                poidsAUtiliser,
                correct == 1 ? "Oui" : "Non"
            );
        }

        private void btnAjouterQCS_Click(object sender, EventArgs e)
        {
            string proposition = txtProposition.Text.Trim();

            if (string.IsNullOrEmpty(proposition))
            {
                MessageBox.Show("Veuillez saisir une proposition.");
                return;
            }

            // Vérifier si une bonne réponse a déjà été cochée
            // vérifier si c'est pour l même question
            if (checkBoxCorrecte.Checked)
            {
                foreach (DataGridViewRow row in DGVReponses.Rows)
                {
                    if (row.Cells["Correct"].Value?.ToString() == "Oui")
                    {
                        MessageBox.Show("Il ne peut y avoir qu'une seule réponse correcte.");
                        return;
                    }
                }
            }

            // Calcul du poids
            int poids = 0;
            if (!string.IsNullOrEmpty(txtPoidsQCS.Text.Trim()))
            {
                if (!int.TryParse(txtPoidsQCS.Text.Trim(), out poids))
                {
                    MessageBox.Show("Le poids doit être un entier.");
                    return;
                }
            }

            // Si c’est la bonne réponse et qu’aucun poids n’a été mis, on le met à 1
            if (checkBoxCorrecte.Checked && poids == 0)
            {
                poids = 1;
            }

            // Ajout dans le DataGridView (question pas encore ajoutée en base, donc pas d'ID pour l’instant)
            DGVReponses.Rows.Add(
                txtboxLibelle.Text,
                proposition,
                poids,
                checkBoxCorrecte.Checked ? "Oui" : "Non"
            );

            // Nettoyage des champs
            txtProposition.Clear();
            txtPoidsQCS.Clear();
            checkBoxCorrecte.Checked = false;
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            GQuestionnaire gqForm = new GQuestionnaire();
            gqForm.Show();
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Voulez-vous vraiment annuler ? Les modifications non enregistrées seront perdues.",
                                 "Confirmation",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                GQuestionnaire gqForm = new GQuestionnaire();
                gqForm.Show();
                this.Close();
            }
        }
    }



}

