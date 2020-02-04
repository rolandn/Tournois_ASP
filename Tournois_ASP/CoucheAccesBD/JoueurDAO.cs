using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tournois_ASP.Models;

namespace Tournois_ASP.CoucheAccesBD
{
    public class JoueurDAO : BaseDAO<Joueur>
    {
        private object idj;

        /**
* Constructeur
* param sqlCmd : la commande SQL contenant la connexion à la base de données
*/
        public JoueurDAO(SqlCommand sqlCmd) : base(sqlCmd)
        {
        }

        /**
         * // ********* LISTER TOUS  *******************
         */
        public override List<Joueur> ListerTous()
        {
            List<Joueur> liste = new List<Joueur>();
            try
            {
                SqlCmd.CommandText =
                 "select idj, nom, prenom, style, nomImage " +
                    "from joueurs " +
                    "order by nom asc";
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                while (sqlReader.Read() == true)
                    liste.Add(new Joueur(Convert.ToInt32(sqlReader["idj"]),
                    Convert.ToString(sqlReader["nom"]),
                    Convert.ToString(sqlReader["prenom"]),
                    Convert.ToString(sqlReader["style"]),
                    Convert.ToString(sqlReader["nomImage"])));
                sqlReader.Close();

            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
            return liste;
        }

        // ********** AJOUTER UN JOUEUR  ************************

        public override void Ajouter(Joueur obj)
        {
            try
            {
                int numJoueur;
                SqlCmd.CommandText = "select max(idj) + 1 from joueurs";
                SqlCmd.Parameters.Clear();
                SqlDataReader sqlReader = SqlCmd.ExecuteReader();
                sqlReader.Read();
                if (sqlReader[0] == DBNull.Value)
                    numJoueur = 1;
                else
                    numJoueur = Convert.ToInt32(sqlReader[0]);
                sqlReader.Close();
                SqlCmd.CommandText =
                "insert into joueur(idj,nom,prenom,style,nomImage) " +
               "values(@idj,@Nnom,@prenom,@style,@nomImage)";
                SqlCmd.Parameters.Clear();
                SqlCmd.Parameters.Add("@idj", SqlDbType.Int).Value = idj;
                SqlCmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.Nom;
                SqlCmd.Parameters.Add("@prenom", SqlDbType.VarChar).Value = obj.Prenom;
                SqlCmd.Parameters.Add("@style", SqlDbType.VarChar).Value = obj.Style;
                SqlCmd.Parameters.Add("@Annee", SqlDbType.VarChar).Value = obj.NomImage;
               
                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
        }
    }
}
