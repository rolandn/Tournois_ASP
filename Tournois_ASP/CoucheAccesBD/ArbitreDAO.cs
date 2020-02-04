using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tournois_ASP.Models;

namespace Tournois_ASP.CoucheAccesBD
{
    public class ArbitreDAO : BaseDAO<Arbitre>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public ArbitreDAO(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

       


        // ********* LISTER TOUS  *******************

        public override List<Arbitre> ListerTous()
        {
            List<Arbitre> liste = new List<Arbitre>();
            try
            {
                SqlCmd.CommandText =
                 "select ida, nom, prenom, experience " +
                    "from arbitres " +
                    "order by ida asc ";
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add(new Arbitre(Convert.ToInt32(sqlReader["ida"]),
                    Convert.ToString(sqlReader["nom"]),
                    Convert.ToString(sqlReader["prenom"]),
                    Convert.ToInt32(sqlReader["experience"])));
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
