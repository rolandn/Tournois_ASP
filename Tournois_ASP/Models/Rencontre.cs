using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournois_ASP.Models
{
    public class Rencontre
    {
        public int Idr { get; set; }
        public string Phase { get; set; }
        public int NumEquipe1 { get; set; }
        public int NumEquipe2 { get; set; }
        public int NumArbitre { get; set; }
        public int NumTable { get; set; }
        public int NumGagnant { get; set; }
        public string Score { get; set; }

        public Rencontre() { }

        public Rencontre (int idr, string phase, int numEquipe1, int numEquipe2, int numArbitre, int numTable, int numGagnant, string score)
        {
            Idr = idr;
            Phase = phase;
            NumEquipe1 = numEquipe1;
            NumEquipe2 = numEquipe2;
            NumArbitre = numArbitre;
            NumTable = numTable;
            NumGagnant = numGagnant;
            Score = score;
        }
    }
}
