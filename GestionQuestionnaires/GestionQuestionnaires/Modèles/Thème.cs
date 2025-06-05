using GestionQuestionnaires.Contrôleurs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestionQuestionnaires.Modèles
{
    internal class Theme
    {
        public int id { get; set; }
        public string nom { get; set; }
        public override string ToString() 
        {
            return nom; 
        }
        public Theme()
        {
            id = 0;
            nom = string.Empty;
        }

    
        public Theme(string nom, int id)
        {
            this.id = id;
            this.nom = nom;
        }

        public static List<Theme> GetThemes()
        {
            var themeListe = new List<Theme>();

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
                    string query = "SELECT Id, Nom FROM theme;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var theme = new Theme
                            {
                                id = reader.GetInt32("Id"),
                                nom = reader.GetString("Nom")
                            };
                            themeListe.Add(theme);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des thèmes : {ex.Message}");
            }

            return themeListe;
        }


        //Thème theme = null;
        public static Theme GetThemeParId(int id)
        {
            Theme theme = null;

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
                    string query = "SELECT * FROM theme WHERE Id = @id";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                theme = new Theme
                                {
                                    id = reader.GetInt32("Id"),
                                    nom = reader.GetString("Nom")
                                };
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des thèmes : {ex.Message}");
            }

            return theme;
        }


        //public static void EnregistrerTheme(int themeid)
        //{
        //    themeid = ThemeController.SelectionnerLigneComboBox(id);
        //}


    }
}
