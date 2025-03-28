using GestionQuestionnaires.Contrôleurs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestionQuestionnaires.Modèles
{
    internal class Thème
    {
        public int id { get; set; }
        public string nom { get; set; }
        public override string ToString() 
        {
            return nom; 
        }
        public Thème()
        {
            id = 0;
            nom = string.Empty;
        }

    
        public Thème(string nom, int id)
        {
            this.id = id;
            this.nom = nom;
        }

        public static List<Thème> GetThemes()
        {
            var themeListe = new List<Thème>();

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
                            var theme = new Thème
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


        //public static void EnregistrerTheme(int themeid)
        //{
        //    themeid = ThemeController.SelectionnerLigneComboBox(id);
        //}


    }
}
