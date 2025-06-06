using GestionQuestionnaires.Modèles;
using GestionQuestionnaires.Contrôleurs;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionQuestionnaires.Vues
{
    public partial class EditerQuestion : Form
    {
        private int questionId;
        private int questionnaireId;
        private Question MaQuestion = new Question();
        private BindingList<Valeur> valeursListe = new BindingList<Valeur>();
        private EditerQuestionnaireForm parentForm;

        public EditerQuestion(int idQuestion, EditerQuestionnaireForm parent)
        {
            InitializeComponent();
            questionId = idQuestion;
            parentForm = parent;
            chargerMaQuestion(questionId);
            groupBoxVraiFaux.Visible = false;
            gpboxQCS.Visible = false;
        }

        public void chargerMaQuestion(int id)
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
                    string query = "SELECT Id, Libelle, TypeId FROM question WHERE id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MaQuestion.Id = reader.GetInt32("Id");
                                MaQuestion.Libelle = reader.GetString("Libelle");
                                MaQuestion.TypeId = reader.GetInt32("TypeId"); // ← correction ici

                                txtLibelle.Text = MaQuestion.Libelle;
                            }
                            else
                            {
                                MessageBox.Show("Aucune question trouvée avec cet ID.");
                                return;
                            }
                        }
                    }
                    AfficherComposantsSelonType();
                    try
                    {
                        int idQuestionnaire = QuestionController.RetournerQuestionnaireIdByQuestion(MaQuestion);
                        MessageBox.Show("ID Questionnaire récupéré = " + idQuestionnaire);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors du retour de l'ID du questionnaire : " + ex.Message);
                    }
                    // Charger les types
                    TypeController.RemplirComboBoxAvecBonType(cmbType, MaQuestion.TypeId);

                    // Charger les valeurs associées
                    ValeurController.RemplirDGVavecValeurs(dgvPropositions, id);
                }
                else
                {
                    MessageBox.Show("Connexion à la base de données échouée.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de la question : {ex.Message}");
            }
        }


        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                MessageBox.Show("Le libellé de la question ne peut pas être vide.");
                return;
            }

            try
            {
                MaQuestion.Libelle = txtLibelle.Text;
                MaQuestion.TypeId = (int)cmbType.SelectedValue;
                QuestionController.ModifierQuestion(MaQuestion);

                foreach (Valeur v in valeursListe)
                {
                    if (v.Id == 0)
                        ValeurController.AjouterValeur(v); // méthode à créer dans ValeurController
                    else
                        ValeurController.MettreAJourValeur(v);
                }


                if (MaQuestion.TypeId == 1)
                {
                    bool estVrai = radioVrai.Checked;
                    int poids = 0;
                    int.TryParse(txtPoidsVF.Text, out poids);
                    ValeurController.MettreAJourVraiFaux(MaQuestion.Id, estVrai, poids);
                }

                MessageBox.Show("La question a été modifiée avec succès.");
                int idQuestionnaire = QuestionController.RetournerQuestionnaireIdByQuestion(MaQuestion);
                parentForm.RechargerQuestionnaire(idQuestionnaire);
                this.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la sauvegarde : " + ex.Message);
            }
        }


        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            int idQuestionnaire = QuestionController.RetournerQuestionnaireIdByQuestion(MaQuestion);
            this.Hide();

            if (parentForm != null)
            {
                parentForm.RechargerQuestionnaire(idQuestionnaire);
                parentForm.Show();
            }
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

            ValeurController.AjouterValeur(valeur);

             
        }


        private void AfficherComposantsSelonType()
        {
            valeursListe.Clear(); // Important : vider la liste avant de remplir

            dgvPropositions.AutoGenerateColumns = false;
            dgvPropositions.Columns.Clear();
            dgvPropositions.DataSource = null;

            if (MaQuestion.TypeId == 1) // Vrai/Faux
            {
                groupBoxVraiFaux.Visible = true;
                gpboxQCS.Visible = false;

                // Charger la réponse et le poids
                ValeurController.ChargerVF(MaQuestion.Id, radioVrai, radioFaux, txtPoidsVF);
            }
            else if (MaQuestion.TypeId == 3) // QCS
            {
                if (dgvPropositions.Rows.Count == 0)
                {
                    MessageBox.Show("Ajoutez au moins une réponse avant de sauvegarder la question.");
                    return;
                }
                dgvPropositions.DefaultCellStyle.ForeColor = Color.Black;
                groupBoxVraiFaux.Visible = false;
                gpboxQCS.Visible = true;

                valeursListe = new BindingList<Valeur>(ValeurController.ObtenirValeursParQuestionId(MaQuestion.Id));

                dgvPropositions.Columns.Clear();

                var colLibelle = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Nom_Valeur",
                    HeaderText = "Proposition",
                    Width = 200
                };
                dgvPropositions.Columns.Add(colLibelle);

                var colCorrect = new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "Correct",
                    HeaderText = "Correct",
                    Width = 60
                };
                dgvPropositions.Columns.Add(colCorrect);

                var colPoids = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Poids",
                    HeaderText = "Poids",
                    Width = 60
                };
                dgvPropositions.Columns.Add(colPoids);

                dgvPropositions.DataSource = valeursListe;
                dgvPropositions.AllowUserToAddRows = false;
                dgvPropositions.AllowUserToDeleteRows = false;
                dgvPropositions.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvPropositions.Columns.Add("Id", "Id");
                dgvPropositions.Columns["Id"].Visible = false;
                dgvPropositions.Columns.Add("Nom_Valeur", "Libellé");
                dgvPropositions.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "Correct", HeaderText = "Correcte" });
                dgvPropositions.Columns.Add("Poids", "Poids");


                dgvPropositions.CellContentClick -= dgvPropositions_CellContentClick;
                dgvPropositions.CellContentClick += dgvPropositions_CellContentClick;
            }

        }



        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedValue != null && int.TryParse(cmbType.SelectedValue.ToString(), out int selectedType))
            {
                MaQuestion.TypeId = selectedType;
                AfficherComposantsSelonType();
            }
        }





        private void btnAjouterProposition_Click(object sender, EventArgs e)
        {
            string proposition = txtboxReponse.Text.Trim();
            bool correct = checkBoxCorrecte.Checked;

            if (string.IsNullOrEmpty(proposition))
            {
                MessageBox.Show("Veuillez saisir une proposition.");
                return;
            }

            int poids = 0;
            if (!string.IsNullOrEmpty(txtboxPoidsQCS.Text.Trim()) && !int.TryParse(txtboxPoidsQCS.Text.Trim(), out poids))
            {
                MessageBox.Show("Le poids doit être un entier.");
                return;
            }

            if (correct && valeursListe.Any(v => v.Correct))
            {
                MessageBox.Show("Il ne peut y avoir qu'une seule réponse correcte.");
                return;
            }

            if (correct && poids == 0)
                poids = 1;

            Valeur nouvelleValeur = new Valeur
            {
                Nom_Valeur = proposition,
                Correct = correct,
                Poids = poids,
                QuestionId = MaQuestion.Id
            };

            valeursListe.Add(nouvelleValeur);

            txtboxReponse.Clear();
            txtboxPoidsQCS.Clear();
            checkBoxCorrecte.Checked = false;
        }





        private void btnSupprimerProposition_Click(object sender, EventArgs e)
        {
            if (dgvPropositions.CurrentRow != null)
            {
                Valeur selected = (Valeur)dgvPropositions.CurrentRow.DataBoundItem;
                if (MessageBox.Show("Supprimer cette proposition ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    valeursListe.Remove(selected);
                    if (selected.Id > 0)
                    {
                        ValeurController.SupprimerValeur(selected.Id);
                    }

                }
            }
        }

        public static void ChargerVF(int questionId, RadioButton radioVrai, RadioButton radioFaux, TextBox txtPoids)
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
                    string query = "SELECT Nom_Valeur, Correct, Poids FROM valeur WHERE QuestionId = @questionId";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@questionId", questionId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nom = reader.GetString("Nom_Valeur");
                                bool correct = reader.GetBoolean("Correct");
                                int poids = reader.GetInt32("Poids");

                                if (nom.ToLower() == "vrai")
                                {
                                    radioVrai.Checked = correct;
                                }
                                else if (nom.ToLower() == "faux")
                                {
                                    radioFaux.Checked = correct;
                                }

                                txtPoids.Text = poids.ToString();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cargation VF échouée.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de la question : {ex.Message}");
            }



        }

        private void ChargerPropositions(int questionId)
        {
            dgvPropositions.Rows.Clear();

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
                    string query = "SELECT Id, Nom_Valeur, Correct, Poids FROM valeur WHERE QuestionId = @questionId";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@questionId", questionId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nomValeur = reader.GetString(1);
                                bool correct = reader.GetBoolean(2);
                                int poids = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                                dgvPropositions.Rows.Add(id, nomValeur, correct, poids);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cargation VF échouée.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de la question : {ex.Message}");
            }
           
        }



        private void dgvPropositions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MaQuestion.TypeId == 3 && dgvPropositions.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                foreach (DataGridViewRow row in dgvPropositions.Rows)
                {
                    if (row.Index != e.RowIndex)
                    {
                        row.Cells["Correct"].Value = false;
                    }
                }

                dgvPropositions.EndEdit(); // Applique immédiatement les changements
            }
        }
    }
}
