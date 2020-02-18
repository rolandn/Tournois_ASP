using System;
using System.Collections.Generic;
using System.Data;
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

        // ********** AJOUTER UNE EQUIPE  ************************

        public override void Ajouter(Equipe obj)
        {
            try
            {
                int ide;
                SqlCmd.CommandText = "select max(ide) + 1 from equipe";
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                sqlReader.Read();
                if (sqlReader[0] == DBNull.Value)
                    ide = 1;
                else
                    ide = Convert.ToInt32(sqlReader[0]);
                sqlReader.Close();
                SqlCmd.CommandText =
                "insert into equipe(ide,nom,joueur1,joueur2) " +
               "values(@ide,@nom,@joueur1,@joueur2)";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@ide", SqlDbType.Int).Value = ide;
                SqlCmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.Nom;
                SqlCmd.Parameters.Add("@joueur1", SqlDbType.Int).Value = obj.Joueur1;
                SqlCmd.Parameters.Add("@joueur2", SqlDbType.Int).Value = obj.Joueur2;
           

                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
        }
    }
}
