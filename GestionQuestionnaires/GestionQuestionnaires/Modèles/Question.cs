using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionQuestionnaires.Modèles
{
    internal class Question
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int TypeId { get; set; } 
        public int QuestionnaireId { get; set; }
        public List<Valeur> Valeurs { get; set; } = new List<Valeur>();

        public Question()
        {
            Id = 0;
            Libelle = string.Empty;
            TypeId = 0;
            QuestionnaireId = 0;
        }

        public Question(int id, string libelle, int typeDeReponse, int questionnaireid)
        {
            Id = id;
            Libelle = libelle;
            TypeId = typeDeReponse;
            QuestionnaireId = questionnaireid;
        }

        public static List<Question> GetQuestions(int questionnaireId)
        {
            var questions = new List<Question>();

            try
            {
                var DBCon = new GQConnexion
                {
                    Server = "localhost",
                    DatabaseName = "gestionquestionnaire",
                    UserName = "root",
                    Password = Crypto.Decrypt("xHhoy9Gmtj6SXFZCpaR+0g==")
                };

                if (DBCon.IsConnect())
                {
                    string query = "SELECT Id, Libelle, TypeId, QuestionnaireId FROM question WHERE QuestionnaireId = @QuestionnaireId;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@QuestionnaireId", questionnaireId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                questions.Add(new Question(
                                    reader.GetInt32("Id"),
                                    reader.GetString("Libelle"),
                                    reader.GetInt32("TypeId"),
                                    reader.GetInt32("QuestionnaireId")

                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des questions : {ex.Message}");
            }

            return questions;
        }

        public static bool AjouterQuestion(Question question, int questionnaireId)
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

                if (DBCon.IsConnect())
                {
                    string query = "INSERT INTO question (Libelle, TypeDeReponse, QuestionnaireId) VALUES (@Libelle, @TypeDeReponse, @QuestionnaireId);";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Libelle", question.Libelle);
                        cmd.Parameters.AddWithValue("@TypeId", question.TypeId);
                        cmd.Parameters.AddWithValue("@QuestionnaireId", questionnaireId);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ajout de la question : {ex.Message}");
            }

            return false;
        }

        public static bool ModifierQuestion(Question question)
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

                if (DBCon.IsConnect())
                {
                    string query = "UPDATE question SET Libelle = @Libelle, TypeDeReponse = @TypeDeReponse WHERE Id = @Id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Libelle", question.Libelle);
                        cmd.Parameters.AddWithValue("@TypeDeReponse", question.TypeId);
                        cmd.Parameters.AddWithValue("@Id", question.Id);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la modification de la question : {ex.Message}");
            }

            return false;
        }

        public static bool SupprimerQuestion(int id)
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

                if (DBCon.IsConnect())
                {
                    string query = "DELETE FROM question WHERE Id = @Id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression de la question : {ex.Message}");
            }

            return false;
        }
    }
}
