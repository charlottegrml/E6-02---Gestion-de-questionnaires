using GestionQuestionnaires.Modèles;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires.Contrôleurs
{
    internal class QuestionController
    {
        public static List<Question> ToutesLesQuestions(int questionnaireId)
        {
            return Question.GetQuestions(questionnaireId);
        }

        public static void RemplirDGVavecQuestions(DataGridView dgv, int questionnaireId)
        {
            List<Question> questions = Question.GetQuestions(questionnaireId);
            dgv.DataSource = questions;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Columns["libelle"].HeaderText = "Noms des Questions : ";
            dgv.Columns["Id"].Visible = false;
            //dgv.Columns[1].Visible = false;
            dgv.Columns["QuestionnaireId"].Visible = false;
            dgv.Columns["TypeId"].Visible = false;


        }
        public static void CreerQuestion(string libelle, string type, List<string> valeurs)
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
                    string query = "INSERT INTO question (Libelle, Type, Valeurs) VALUES (@libelle, @type, @valeurs);";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@libelle", libelle);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@valeurs", string.Join(",", valeurs));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification de la question : {ex.Message}");
            }


            

        }
        public static void ModifierQuestion(int id, string libelle, string type, List<string> valeurs)
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
                    string query = "UPDATE question SET Libelle = @libelle, Type = @type, Valeurs = @valeurs WHERE Id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@libelle", libelle);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@valeurs", string.Join(",", valeurs));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification de la question : {ex.Message}");
            }
        }



        public static void SupprimerQuestion(int id)
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
                    // 1. Supprimer les valeurs liées à la question
                    string deleteValeurs = "DELETE FROM valeur WHERE QuestionId = @id;";
                    using (var cmdValeurs = new MySqlCommand(deleteValeurs, DBCon.Connection))
                    {
                        cmdValeurs.Parameters.AddWithValue("@id", id);
                        cmdValeurs.ExecuteNonQuery();
                    }

                    // 2. Supprimer les réponses utilisateur liées à la question (optionnel selon ton modèle)
                    string deleteReponses = "DELETE FROM reponses_utilisateur WHERE QuestionId = @id;";
                    using (var cmdReponses = new MySqlCommand(deleteReponses, DBCon.Connection))
                    {
                        cmdReponses.Parameters.AddWithValue("@id", id);
                        cmdReponses.ExecuteNonQuery();
                    }

                    // 3. Supprimer la question
                    string deleteQuestion = "DELETE FROM question WHERE Id = @id;";
                    using (var cmdQuestion = new MySqlCommand(deleteQuestion, DBCon.Connection))
                    {
                        cmdQuestion.Parameters.AddWithValue("@id", id);
                        cmdQuestion.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de la question : {ex.Message}");
            }
        }

        public static Question ObtenirQuestionParId(int id)
        {
            Question question = null;
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
                    string query = "SELECT * FROM question WHERE Id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                question = new Question
                                {
                                    Id = reader.GetInt32("Id"),
                                    Libelle = reader.GetString("Libelle"),
                                    QuestionnaireId = reader.GetInt32("QuestionnaireId"),
                                    TypeId = reader.GetInt32("TypeId")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de la question : {ex.Message}");
            }

            return question;
        }


        public static void ModifierQuestion(Question q)
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
                        string query = "UPDATE question SET Libelle = @libelle WHERE Id = @id;";
                        using (var cmd = new MySqlCommand(query, DBCon.Connection))
                        {
                            cmd.Parameters.AddWithValue("@libelle", q.Libelle);
                            cmd.Parameters.AddWithValue("@id", q.Id);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la modification de la question : {ex.Message}");
                }



        }

        public static int AjouterQuestionEtRetournerId(Question question)
        {
            int insertedId = -1;

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
                    string query = "INSERT INTO question (Libelle, QuestionnaireId, TypeId) VALUES (@libelle, @questionnaireId, @typeId); SELECT LAST_INSERT_ID();";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@libelle", question.Libelle);
                        cmd.Parameters.AddWithValue("@questionnaireId", question.QuestionnaireId);
                        cmd.Parameters.AddWithValue("@typeId", question.TypeId);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            insertedId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'insertion de la question : {ex.Message}");
            }

            return insertedId;
        }

        public static int RetournerQuestionnaireIdByQuestion(Question question)
        {
            int IdQuestionnaire = 0;

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
                    string query = "SELECT QuestionnaireId FROM question WHERE Id = @Id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", question.Id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IdQuestionnaire = reader.GetInt32("QuestionnaireId");
                            }
                            else
                            {
                                MessageBox.Show("Aucune question trouvée avec cet Id.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erreur de connexion à la base de données.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de QuestionnaireId : {ex.Message}");
            }

            return IdQuestionnaire;
        }

    }



}

