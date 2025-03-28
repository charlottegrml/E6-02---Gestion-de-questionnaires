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




        public static void RemplirComboBox (ComboBox comboBox)
        {

            try
            {
                List<Thème> themelist = Thème.GetThemes();
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
                            themelist.Add (new Thème
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


        public static void SelectionnerLigneComboBox(ComboBox comboBox, int id)
        {
            comboBox.SelectedValue = id;


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
                    string query = "UPDATE Id, Nom FROM theme;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        //themelist.Clear();
                        while (reader.Read())
                        {
                            //themelist.Add(new Thème
                            //{
                            //    id = reader.GetInt32("Id"),
                            //    nom = reader.GetString("Nom")
                            //});
                        }
                    }
                }


            }

            catch
            {

            }
        }

        //public static void EnregistrerTheme(ComboBox comboBox, int id)
        //{

        //}
    }
}



