using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tournois_ASP.Models;

namespace Tournois_ASP.CoucheAccesBD
{
    public class EquipeDAO: BaseDAO<Equipe>
    {

        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public EquipeDAO(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * méthode qui lit dans la base de données tous les élèves
         * retour : la liste de tous les élèves
         */


        // ********* LISTER TOUS  *******************

        public override List<Equipe> ListerTous()
        {
            List<Equipe> liste = new List<Equipe>();
            try
            {
                SqlCmd.CommandText =
                 "select ide, nom, joueur1, joueur2 " +
                    "from equipe " +
                    "order by ide asc ";
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add(new Equipe(Convert.ToInt32(sqlReader["ide"]),
                    Convert.ToString(sqlReader["nom"]),
                    Convert.ToInt32(sqlReader["joueur1"]),
                    Convert.ToInt32(sqlReader["joueur2"])));
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
