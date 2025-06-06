using GestionQuestionnaires;
using GestionQuestionnaires.Modèles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires.Contrôleurs
{
    internal class ThemeController
    {
        //public static List<Thème> TousLesThemes()
        //{
        //    List<Thème> themelist = Thème.GetThemes();
        //    return themelist;
        //}


        public static void RemplirComboBox(ComboBox comboBox)
        {

            try
            {
                List<Theme> themelist = Theme.GetThemes();
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
                        themelist.Clear();
                        while (reader.Read())
                        {
                            themelist.Add(new Theme
                            {
                                id = reader.GetInt32("Id"),
                                nom = reader.GetString("Nom")
                            });
                        }
                    }
                }
                comboBox.Items.Clear();
                comboBox.DataSource = themelist;
                comboBox.DisplayMember = "Nom";
                comboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des thèmes : {ex.Message}");
            }

        }


        public static void RemplirComboBoxAvecBonTheme(ComboBox comboBox, int idTheme)
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
                    List<Theme> themes = new List<Theme>();

                    string query = "SELECT Id, Nom FROM theme ORDER BY Nom;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Theme t = new Theme
                            {
                                id = reader.GetInt32("Id"),
                                nom = reader.GetString("Nom")
                            };
                            themes.Add(t);
                        }
                    }

                    comboBox.DataSource = themes;
                    comboBox.DisplayMember = "Nom";
                    comboBox.ValueMember = "Id";

                    // Sélectionner le bon thème après avoir défini la source
                    comboBox.SelectedValue = idTheme;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection des thèmes : {ex.Message}");
            }
        }



    }
}



