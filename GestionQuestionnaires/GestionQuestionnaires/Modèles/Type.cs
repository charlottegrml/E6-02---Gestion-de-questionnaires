using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionQuestionnaires.Modèles
{
    internal class Types
    {
        public int id { get; set; }
        public string libelle { get; set; }

        public Types()
        {
            id = 0;
            libelle = string.Empty;
        }

        public Types(string nom, int id)
        {
            this.id = id;
            this.libelle = nom;
        }

        public static List<Types> GetTypes()
        {
            var typeListe = new List<Types>();

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
                    string query = "SELECT Id, Libelle FROM type;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var type = new Types
                            {
                                id = reader.GetInt32("Id"),
                                libelle = reader.GetString("Libelle")
                            };
                            typeListe.Add(type);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des types : {ex.Message}");
            }

            return typeListe;
        }


    }
}
