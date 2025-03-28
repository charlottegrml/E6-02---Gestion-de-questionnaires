using GestionQuestionnaires.Modèles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionQuestionnaires.Contrôleurs
{
    internal class TypeController
    {
        public static List<Modèles.Type> TousLesTypes()
        {
            return Modèles.Type.GetTypes();  
        }
    }
}
