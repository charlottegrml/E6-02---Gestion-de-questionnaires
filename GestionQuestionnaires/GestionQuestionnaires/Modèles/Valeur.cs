using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires.Modèles
{
    internal class Valeur
    {
        public int Id { get; set; }
        public string Texte { get; set; } 
        public bool EstCorrecte { get; set; } 
        public int QuestionId { get; set; }
    }
}
