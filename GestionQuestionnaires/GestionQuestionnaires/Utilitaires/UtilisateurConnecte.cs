using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires.Utilitaires
{
    public static class UtilisateurConnecte
    {
        public static int Id { get; set; }
        public static string NomUtilisateur { get; set; }
        public static string Nom { get; set; }
        public static string Prenom { get; set; }

        public static void Deconnexion()
        {
            Id = 0;
            NomUtilisateur = null;
            Nom = null;
            Prenom = null;
        }
    }

}
