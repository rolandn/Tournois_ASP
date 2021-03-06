﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Tournois_ASP.CoucheAccesBD;


namespace Tournois_ASP.CoucheAccesBD
{
    public class FabriqueDAO
    {
        private SqlCommand SqlCmd;
        /**
        * Constructeur : il crée la connexion avec la base de données
        */
        public FabriqueDAO()
        {
            try
            {
                SqlCmd = new SqlCommand();
                SqlCmd.Connection = new SqlConnection("Integrated security=false;" +
                "user id=genial;" +
               "password=super;" +
               "Data Source=ROLAND-PC\\SQLEXPRESS;" +
               "Initial Catalog=TOURNOIS;");
                SqlCmd.Connection.Open();
            }
            catch (Exception e)
            {
                throw new ExceptionAccesBD(e.Message);
            }
        }
        /**
        * méthode qui fournit une instance d'objet
        * retour : l'instance d'objet
        */
        public EquipeDAO GetEquipeDAO()
        {
            return new EquipeDAO(SqlCmd);
        }

        public JoueurDAO GetJoueurDAO()
        {
            return new JoueurDAO(SqlCmd);
        }

        public ArbitreDAO GetArbitreDAO()
        {
            return new ArbitreDAO(SqlCmd);
        }

        public RencontreDAO GetRencontreDAO()
        {
            return new RencontreDAO(SqlCmd);
        }

        public TableDAO GetTableDAO()
        {
            return new TableDAO(SqlCmd);
        }


        /**
        * méthode qui débute explicitement une transaction
        * 
        * */
        public void DebuterTransaction()
        {
            SqlCmd.Transaction = SqlCmd.Connection.BeginTransaction();
        }
        /**
        * méthode qui valider explicitement la transaction courante
        */
        public void ValiderTransaction()
        {
            SqlCmd.Transaction.Commit();
        }
        /**
        * méthode qui annule explicitement la transaction courante
        */
        public void AnnulerTransaction()
        {
            SqlCmd.Transaction.Rollback();
        }
    }

}
