using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tournois_ASP.Models;
using Tournois_ASP.CoucheAccesBD;

namespace Tournois_ASP.Controllers
{
    public class RencontreController : Controller
    {
        private FabriqueDAO FabDAO = new FabriqueDAO();
        // Méthode qui sélectionne la vue qui liste tous les cours
        [HttpGet]

        // ********* LISTER TOUS  *******************


        public IActionResult ListerTous()
        {
            try
            {
                ViewBag.ListeRencontre = FabDAO.GetRencontreDAO().ListerTous();
                return View();
            }
            catch (ExceptionAccesBD e)
            {
                ViewBag.Message = e.Message;
                return View("Erreur");
            }
        }

    }
}
