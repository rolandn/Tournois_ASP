using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Tournois_ASP.CoucheAccesBD
{
    public class BaseDAO<T>
    {
        protected SqlCommand SqlCmd;
        /**
        * Constructeur
        * param sqlCmd : la commande SQL contenant la connexion à la base de données
        */
        public BaseDAO(SqlCommand sqlCmd)
        {
            SqlCmd = sqlCmd;
        }
        /**
        * Méthodes dont le comportement doit être défini dans les sous-classes DAO
        */
        public virtual T Charger(int num)
        {
            return default(T);
        }
        public virtual void Ajouter(T obj)
        {
        }
        public virtual void Modifier(T obj)
        {
        }
        public virtual void Supprimer(int num)
        {
        }
        public virtual List<T> ListerTous()
        {
            return null;
        }
    }

}
