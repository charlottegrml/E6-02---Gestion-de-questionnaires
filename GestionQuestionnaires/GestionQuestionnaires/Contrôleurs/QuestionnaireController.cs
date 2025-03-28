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
            return Questionnaire.GetQuestionnaires(); 
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
                    string query = "DELETE FROM questionnaire WHERE Id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression du questionnaire : {ex.Message}");
            }
        }
    }
}
