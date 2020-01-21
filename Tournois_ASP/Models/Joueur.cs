using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournois_ASP.Models
{
    public class Joueur
    {
        public int Idj { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Style { get; set; }
        public string NomImage { get; set; }

        public Joueur(int idj, string nom, string prenom, string style, string nomImage)
        {
            Idj = idj;
            Nom = nom;
            Prenom = prenom;
            Style = style;
            NomImage = nomImage;
        }
    }
}
