using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GestionQuestionnaires.Modèles
{
    public class Valeur
    {
        public int Id { get; set; }
        public string Nom_Valeur { get; set; }
        public int QuestionId { get; set; }
        public bool Correct { get; set; }
        public int Poids { get; set; }

        // Constructeur vide pour lier les données)
        public Valeur() { }

        // Constructeur avec paramètres (optionnel, utile si tu veux instancier rapidement)
        public Valeur(int id, string nomValeur, int questionId, bool correct, int poids)
        {
            Id = id;
            Nom_Valeur = nomValeur;
            QuestionId = questionId;
            Correct = correct;
            Poids = poids;
        }
    }
}
