using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tournois_ASP.Models;
using Tournois_ASP.CoucheAccesBD;
using Tournois_ASP.coucheMetier;

namespace Tournois_ASP.Controllers
{
    public class JoueurController : Controller
    {
        private FabriqueDAO FabDAO = new FabriqueDAO();
        // Méthode qui sélectionne la vue qui liste tous les cours
        [HttpGet]

        // ********* LISTER TOUS  *******************

        public IActionResult ListerTous()
        {
            try
            {
                ViewBag.ListeJoueur = FabDAO.GetJoueurDAO().ListerTous();
                return View();
            }
            catch (ExceptionAccesBD e)
            {
                ViewBag.Message = e.Message;
                return View("Erreur");
            }
        }


        // ************* AJOUTER ********************

        [HttpGet]
        public IActionResult Ajouter()
        {
            return View();
        }

        // Méthode du bouton pour enregistrer le joueur
        [HttpPost]
        public IActionResult AjouterSuite(Joueur joueur)
        {
            try
            {
                
                new CoucheMetier().TesterContraintesJoueur(joueur);
                FabDAO.DebuterTransaction();
                FabDAO.GetJoueurDAO().Ajouter(joueur);
                FabDAO.ValiderTransaction();
                return RedirectToAction("ListerTous");

            }
            catch (ExceptionMetier e)
            {
                ViewBag.Message = e.Message;
            }
            catch (Exception e)
            {
                // on sait que l'upload du fichier a échoué. On peut annuler l'ajout dans la BD
                FabDAO.AnnulerTransaction();
                ViewBag.Message = e.Message;
            }
            return View("Erreur");
        }

    }
}
