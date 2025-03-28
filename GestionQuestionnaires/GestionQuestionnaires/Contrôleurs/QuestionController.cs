using GestionQuestionnaires.Modèles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires.Contrôleurs
{
    internal class QuestionController
    {
        public static List<Question> ToutesLesQuestions(int questionnaireId)
        {
            return Question.GetQuestions(questionnaireId);
        }

        public static void RemplirDGVavecQuestions (DataGridView dgv, int questionnaireId)
        {
            List<Question> questions = Question.GetQuestions(questionnaireId);
            dgv.DataSource = questions;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Columns["libelle"].HeaderText = "Noms des Questions : ";
            dgv.Columns["Id"].Visible = false;
            //dgv.Columns[1].Visible = false;
            dgv.Columns["QuestionnaireId"].Visible = false;
            dgv.Columns["TypeId"].Visible = false;


        }
        public static void CreerQuestion(string libelle, string type, List<string> valeurs)
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
                    string query = "INSERT INTO question (Libelle, Type, Valeurs) VALUES (@libelle, @type, @valeurs);";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@libelle", libelle);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@valeurs", string.Join(",", valeurs));

                        cmd.ExecuteNonQuery();  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création de la question : {ex.Message}");
            }
        }

        public static void ModifierQuestion(int id, string libelle, string type, List<string> valeurs)
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
                    string query = "UPDATE question SET Libelle = @libelle, Type = @type, Valeurs = @valeurs WHERE Id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@libelle", libelle);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@valeurs", string.Join(",", valeurs));

                        cmd.ExecuteNonQuery(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification de la question : {ex.Message}");
            }
        }

        public static void SupprimerQuestion(int id)
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
                    string query = "DELETE FROM question WHERE Id = @id;";
                    using (var cmd = new MySqlCommand(query, DBCon.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de la question : {ex.Message}");
            }
        }
    }
}
