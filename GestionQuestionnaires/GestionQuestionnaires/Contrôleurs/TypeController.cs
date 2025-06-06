using GestionQuestionnaires.Modèles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires.Contrôleurs
{
    internal class TypeController
    {
        //public static List<Modèles.Type> TousLesTypes()
        //{
        //    return Modèles.Type.GetTypes();  
        //}

        public static void RemplirComboBox(ComboBox comboBox)
        {

            try
            {
                List<Modèles.Types> typelist = Modèles.Types.GetTypes();
                GQConnexion DBCon = new GQConnexion
                {
                    Server = "localhost",
                    DatabaseName = "gestionquestionnaire",
                    UserName = "root",
                    Password = Crypto.Decrypt("xHhoy9Gmtj6SXFZCpaR+0g==")
                };

                if (DBCon.IsConnect())
                {
                    string query = "SELECT Id, Libelle FROM type;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        typelist.Clear();
                        while (reader.Read())
                        {
                            typelist.Add(new Modèles.Types
                            {
                                id = reader.GetInt32("Id"),
                                libelle = reader.GetString("Libelle")
                            });
                        }
                    }
                }
                comboBox.Items.Clear();
                comboBox.DataSource = typelist;
                comboBox.DisplayMember = "Libelle";
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
                    string query = "UPDATE Id, Libelle FROM theme;";
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

            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection des thèmes : {ex.Message}");
            }
        }

        public static void RemplirComboBoxAvecBonType(ComboBox comboBox, int idType)
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
                    List<Types> types = new List<Types>();

                    string query = "SELECT Id, Libelle FROM type ORDER BY Libelle;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Types t = new Types
                            {
                                id = reader.GetInt32("Id"),
                                libelle = reader.GetString("Libelle")
                            };
                            types.Add(t);
                        }
                    }

                    comboBox.DataSource = types;
                    comboBox.DisplayMember = "Libelle";
                    comboBox.ValueMember = "Id";

                    // Sélectionner le bon thème après avoir défini la source
                    comboBox.SelectedValue = idType;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection des thèmes : {ex.Message}");
            }
        }
    }
}
