using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournois_ASP.Models
{
    public class Equipe
    {
        public int Ide { get; set; }
        public string Nom { get; set; }
        public int Joueur1 { get; set; }
        public int Joueur2 { get; set; }

        public Equipe (int ide, string nom, int joueur1, int joueur2)
        {
            Ide = ide;
            Nom = nom;
            Joueur1 = joueur1;
            Joueur2 = joueur2;
        }
    }
}
