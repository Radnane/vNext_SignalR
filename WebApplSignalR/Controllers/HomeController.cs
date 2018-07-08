using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplSignalR.Data;
using WebApplSignalR.Models;
using WebApplSignalR.Services;

namespace WebApplSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrajetService trajetService;

        public HomeController()
        {
            trajetService = new TrajetService(new SignalRDbEntities());
        }

        public ActionResult Administration()
        {
            IList<TrajetVM> trajets = GetTrajetsViewModel();
            return View(trajets);
        }

        public ActionResult Affichage()
        {
            IList<TrajetVM> trajets = GetTrajetsViewModel();
            return View(trajets);
        }

        public ActionResult GetTrajet(int id)
        {
            TrajetVM trajetVM = null;
            try
            {
                var trajet = trajetService.GetTrajetById(id);

                if (trajet == null)
                {
                    throw new Exception($"Trajet {id} n'existe pas");
                }

                trajetVM = GetTrajetViewModel(trajet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return View("Trajet", trajetVM);
        }

        [HttpPost]
        public ActionResult Update(TrajetVM trajet)
        {
            try
            {
                trajetService.UpdateTrajet(new Trajet
                {
                    Id = trajet.Id,
                    DateHeureArrivee = trajet.DateHeureArrivee,
                    DateHeureDepart = trajet.DateHeureDepart,
                    GareArrivee = trajet.GareArrivee,
                    GareDepart = trajet.GareDepart,
                    NumeroTrain = trajet.NumeroTrain
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return RedirectToAction("Administration");
        }

        #region private
        private IList<TrajetVM> GetTrajetsViewModel()
        {
            return trajetService.GetTrajets()
                                .Select(x => GetTrajetViewModel(x))
                                .ToList();
        }

        private TrajetVM GetTrajetViewModel(Trajet trajet)
        {
            if(trajet == null)
            {
                throw new ArgumentNullException(nameof(trajet));
            }

            return new TrajetVM()
            {
                Id = trajet.Id,
                NumeroTrain = trajet.NumeroTrain,
                GareDepart = trajet.GareDepart,
                GareArrivee = trajet.GareArrivee,
                DateHeureDepart = trajet.DateHeureDepart,
                DateHeureArrivee = trajet.DateHeureArrivee,
                UpdatedAt = trajet.UpdatedAt
            };
        }

        #endregion

    }
}