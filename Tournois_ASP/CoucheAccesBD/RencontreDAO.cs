using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tournois_ASP.Models;

namespace Tournois_ASP.CoucheAccesBD
{
    public class RencontreDAO : BaseDAO<Rencontre>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public RencontreDAO(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données tous les élèves
         * retour : la liste de tous les élèves
         */


        // ********* LISTER TOUS  *******************

        public override List<Rencontre> ListerTous()
        {
            List<Rencontre> liste = new List<Rencontre>();
            try
            {
                SqlCmd.CommandText =
                 "select idr, phase, NumEquipe1, NumEquipe2, NumArbitre, NumTable, NumGagnant, score " +
                    "from rencontres " +
                    "order by idr asc ";
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add(new Rencontre(Convert.ToInt32(sqlReader["idr"]),
                    Convert.ToString(sqlReader["phase"]),
                    Convert.ToInt32(sqlReader["NumEquipe1"]),
                    Convert.ToInt32(sqlReader["NumEquipe2"]),
                    Convert.ToInt32(sqlReader["NumArbitre"]),
                    Convert.ToInt32(sqlReader["NumTable"]),
                    Convert.ToInt32(sqlReader["NumGagnant"]),
                    Convert.ToString(sqlReader["score"])));
                sqlReader.Close();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
            return liste;
        }
    }
}

