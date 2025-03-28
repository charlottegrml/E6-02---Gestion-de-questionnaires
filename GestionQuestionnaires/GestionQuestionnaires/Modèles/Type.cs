using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionQuestionnaires.Modèles
{
    internal class Type
    {
        public int id { get; set; }
        public string nom { get; set; }

        public Type()
        {
            id = 0;
            nom = string.Empty;
        }

        public Type(string nom, int id)
        {
            this.id = id;
            this.nom = nom;
        }

        public static List<Type> GetTypes()
        {
            var typeListe = new List<Type>();

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
                    string query = "SELECT Id, Nom FROM type;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var type = new Type
                            {
                                id = reader.GetInt32("Id"),
                                nom = reader.GetString("Nom")
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
