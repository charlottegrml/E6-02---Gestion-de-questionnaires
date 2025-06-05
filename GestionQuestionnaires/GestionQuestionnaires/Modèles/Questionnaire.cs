using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionQuestionnaires.Modèles
{
    internal class Questionnaire
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public int ThemeId { get; set; }

        public string ThemeNom { get; set; }


        public Questionnaire()
        {
            Id = 0;
            Libelle = string.Empty;
            ThemeId = 0;
        }

        public Questionnaire(int id, string libelle, int themeid)
        {
            Id = id;
            Libelle = libelle;
            ThemeId = themeid ;
        }

        public static List<Questionnaire> GetQuestionnairesAvecThemes()
        {
            List<Questionnaire> questionnaires = new List<Questionnaire>();

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
                    string query = "SELECT q.Id, q.Libelle, q.ThemeId, t.Nom AS ThemeNom FROM questionnaire q JOIN theme t ON q.ThemeId = t.Id";

                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questionnaires.Add(new Questionnaire
                            {
                                Id = reader.GetInt32("Id"),
                                Libelle = reader.GetString("Libelle"),
                                ThemeId = reader.GetInt32("ThemeId"),
                                ThemeNom = reader.GetString("ThemeNom") // Récupération du nom du thème
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des questionnaires : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return questionnaires;
        }


        public static bool AjouterQuestionnaire(Questionnaire questionnaire)
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
                    string query = "INSERT INTO questionnaire (Libelle) VALUES (@Libelle);";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Libelle", questionnaire.Libelle);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du questionnaire : {ex.Message}");
            }

            return false;
        }

        public static bool ModifierQuestionnaire(Questionnaire questionnaire)
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
                    string query = "UPDATE questionnaire SET Libelle = @Libelle WHERE Id = @Id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Libelle", questionnaire.Libelle);
                        cmd.Parameters.AddWithValue("@Id", questionnaire.Id);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification du questionnaire : {ex.Message}");
            }

            return false;
        }

        public static bool SupprimerQuestionnaire(int id)
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
                    string query = "DELETE FROM questionnaire WHERE Id = @Id;";
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
                MessageBox.Show($"Erreur lors de la suppression du questionnaire : {ex.Message}");
            }

            return false;
        }
    }
}
