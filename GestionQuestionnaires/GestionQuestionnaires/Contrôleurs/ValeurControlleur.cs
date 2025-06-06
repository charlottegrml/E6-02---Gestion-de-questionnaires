using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using GestionQuestionnaires.Modèles;
using System.ComponentModel;

namespace GestionQuestionnaires.Contrôleurs
{
    public class ValeurController
    {
        public static List<Valeur> ObtenirValeursParQuestionId(int questionId)
        {
            List<Valeur> valeurs = new List<Valeur>();

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
                    string query = "SELECT Id, Nom_Valeur, QuestionId, Correct, Poids FROM valeur WHERE QuestionId = @questionId;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@questionId", questionId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Valeur v = new Valeur
                                {
                                    Id = reader.GetInt32("Id"),
                                    Nom_Valeur = reader.GetString("Nom_Valeur"),
                                    QuestionId = reader.GetInt32("QuestionId"),
                                    Correct = reader.GetBoolean("Correct"),
                                    Poids = reader.GetInt32("Poids")
                                };
                                valeurs.Add(v);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des valeurs : " + ex.Message);
            }

            return valeurs;
        }

        public static void MettreAJourValeur(Valeur v)
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
                    string query = "UPDATE valeur SET Nom_Valeur = @nom, Correct = @correct, Poids = @poids WHERE Id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@nom", v.Nom_Valeur);
                        cmd.Parameters.AddWithValue("@correct", v.Correct);
                        cmd.Parameters.AddWithValue("@poids", v.Poids);
                        cmd.Parameters.AddWithValue("@id", v.Id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour d'une valeur : " + ex.Message);
            }
        }

        public static void RemplirDGVavecValeurs(DataGridView dgv, int questionId)
        {
            BindingList<Valeur> valeurs = new BindingList<Valeur>();

            GQConnexion DBCon = new GQConnexion();
            DBCon.Server = "localhost";
            DBCon.DatabaseName = "gestionquestionnaire";
            DBCon.UserName = "root";
            DBCon.Password = Crypto.Decrypt("xHhoy9Gmtj6SXFZCpaR+0g==");

            if (DBCon.IsConnect())
            {
                string query = "SELECT Id, Nom_Valeur, Correct, Poids FROM valeur WHERE QuestionId = @questionId";
                using (var cmd = new MySqlCommand(query, DBCon.Connection))
                {
                    cmd.Parameters.AddWithValue("@questionId", questionId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Valeur v = new Valeur
                            {
                                Id = reader.GetInt32("Id"),
                                Nom_Valeur = reader.GetString("Nom_Valeur"),
                                Correct = reader.GetBoolean("Correct"),
                                Poids = reader.GetInt32("Poids")
                            };
                            valeurs.Add(v);
                        }
                    }
                }

                dgv.DataSource = valeurs;
            }
        }


        public static void ChargerVF(int questionId, RadioButton radioVrai, RadioButton radioFaux, TextBox txtPoids)
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
                    string query = "SELECT Nom_Valeur, Correct, Poids FROM valeur WHERE QuestionId = @questionId;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@questionId", questionId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nom = reader.GetString("Nom_Valeur");
                                bool correct = reader.GetBoolean("Correct");
                                int poids = reader.GetInt32("Poids");

                                if (correct)
                                {
                                    if (nom == "Vrai") radioVrai.Checked = true;
                                    else if (nom == "Faux") radioFaux.Checked = true;

                                    txtPoids.Text = poids.ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement Vrai/Faux : " + ex.Message);
            }
        }

        public static void SupprimerValeur(int id)
        {
            GQConnexion DBCon = new GQConnexion();
            if (DBCon.IsConnect())
            {
                string query = "DELETE FROM valeur WHERE Id = @id";
                using (var cmd = new MySqlCommand(query, DBCon.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void MettreAJourVraiFaux(int questionId, bool estVrai, int poids)
        {
            GQConnexion DBCon = new GQConnexion();
            if (DBCon.IsConnect())
            {
                string query = "UPDATE valeur SET Correct = (@correct), Poids = @poids WHERE QuestionId = @questionId AND Nom_Valeur = @nom";
                using (var cmd = new MySqlCommand(query, DBCon.Connection))
                {
                    cmd.Parameters.AddWithValue("@correct", true);
                    cmd.Parameters.AddWithValue("@poids", poids);
                    cmd.Parameters.AddWithValue("@questionId", questionId);
                    cmd.Parameters.AddWithValue("@nom", estVrai ? "Vrai" : "Faux");
                    cmd.ExecuteNonQuery();

                    // mettre l'autre à false
                    cmd.Parameters["@correct"].Value = false;
                    cmd.Parameters["@nom"].Value = estVrai ? "Faux" : "Vrai";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AjouterValeur(Valeur valeur)
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
                    string query = "INSERT INTO valeur (Nom_Valeur, QuestionId, Correct, Poids) VALUES (@nom, @questionId, @correct, @poids)";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@nom", valeur.Nom_Valeur);
                        cmd.Parameters.AddWithValue("@questionId", valeur.QuestionId);
                        cmd.Parameters.AddWithValue("@correct", valeur.Correct);
                        cmd.Parameters.AddWithValue("@poids", valeur.Poids);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'insertion de la valeur : {ex.Message}");
            }
        }



    }
}
