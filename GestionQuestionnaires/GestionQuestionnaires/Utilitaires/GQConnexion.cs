﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires
{
    internal class GQConnexion
    {

        public GQConnexion()
        {
        }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public MySqlConnection Connection { get; set; }

        private static GQConnexion _instance = null;
        public static GQConnexion Instance()
        {
            if (_instance == null)
                _instance = new GQConnexion();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }

            return true;
        }


        public void Close()
        {
            Connection.Close();
        }
    }
}
