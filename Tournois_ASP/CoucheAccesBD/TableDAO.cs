using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tournois_ASP.Models;

namespace Tournois_ASP.CoucheAccesBD
{
    public class TableDAO : BaseDAO<Table>
    {
        /**
         * Constructeur
         * param sqlCmd : la commande SQL contenant la connexion à la base de données
         */
        public TableDAO(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

       


        // ********* LISTER TOUS  *******************

        public override List<Table> ListerTous()
        {
            List<Table> liste = new List<Table>();
            try
            {
                SqlCmd.CommandText =
                 "select idt, position " +
                    "from tables " +
                    "order by idt asc ";
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add(new Table(Convert.ToInt32(sqlReader["idt"]),
                    Convert.ToInt32(sqlReader["position"])));
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
