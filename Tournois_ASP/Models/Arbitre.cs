using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournois_ASP.Models
{
    public class Arbitre
    {
        public int Ida { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Experience { get; set; }

        public Arbitre () { }

        public Arbitre(int ida, string nom, string prenom, int experience)
        {
            Ida = ida;
            Nom = nom;
            Prenom = prenom;
            Experience = experience;
        }
    }
}
