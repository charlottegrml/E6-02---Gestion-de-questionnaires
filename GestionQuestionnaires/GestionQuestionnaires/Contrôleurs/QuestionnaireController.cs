using GestionQuestionnaires.Modèles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires.Contrôleurs
{
    internal class QuestionnaireController
    {
        public static List<Questionnaire> TousLesQuestionnaires(int questionnaireId)
        {
            return Questionnaire.GetQuestionnairesAvecThemes();
        }

        public static void CreerQuestionnaire(string libelle, int themeId)
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
                    string query = "INSERT INTO questionnaire (Libelle) VALUES (@libelle);";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@libelle", libelle);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création du questionnaire : {ex.Message}");
            }
        }

        public static void ModifierQuestionnaire(int id, string libelle, int themeId)
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
                    string query = "UPDATE questionnaire SET Libelle = @libelle, ThemeId = @themeId WHERE Id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@libelle", libelle);
                        cmd.Parameters.AddWithValue("@themeId", themeId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification du questionnaire : {ex.Message}");
            }
        }

        public static void SupprimerQuestionnaire(int id)
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
                        string deleteReponsesUtilisateur = @"
                    DELETE FROM reponses_utilisateur 
                    WHERE QuestionnaireId = @id;";
                    using (var cmd = new MySqlCommand(deleteReponsesUtilisateur, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                            string deleteValeurs = @"
                        DELETE FROM valeur 
                        WHERE QuestionId IN (
                            SELECT Id FROM question WHERE QuestionnaireId = @id
                        );";
                    using (var cmd = new MySqlCommand(deleteValeurs, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                        string deleteQuestions = @"
                    DELETE FROM question 
                    WHERE QuestionnaireId = @id;";
                    using (var cmd = new MySqlCommand(deleteQuestions, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                        string deleteQuestionnaire = @"
                    DELETE FROM questionnaire 
                    WHERE Id = @id;";
                    using (var cmd = new MySqlCommand(deleteQuestionnaire, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Questionnaire supprimé avec succès !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression du questionnaire : {ex.Message}");
            }
        }



    

        public static Questionnaire GetQuestionnaireParId(int id)
        {
            Questionnaire questionnaire = null;

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
                    string query = "SELECT * FROM questionnaire WHERE Id = @id";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                questionnaire = new Questionnaire
                                {
                                    Id = reader.GetInt32("Id"),
                                    Libelle = reader.GetString("Libelle"),
                                    ThemeId = reader.GetInt32("ThemeId")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération du questionnaire : {ex.Message}");
            }

            return questionnaire;
        }


    }
}