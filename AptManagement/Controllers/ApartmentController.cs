using AptManagement.Data.Context.Dapper.Config;
using AptManagement.Data.Context.Dapper.Repos;
using AptManagement.Data.IRepos;
using AptManagement.Data.Models;
using AptManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AptManagement.Controllers
{
    public class ApartmentController : Controller
    {
        IApartmentRepo _aptRepo;

        // temporary solution since the below constructor doesn't work
        public ApartmentController()
        {
            AppDataContext Context = new AppDataContext();
            _aptRepo = new ApartmentRepo(Context);
        }

        /*
        TODO this works somehow but current project configuration doesn't
        allow this to work. Something related to Ninject i think
        public ApartmentController(IApartmentRepo aptRepo)
        {
            _aptRepo = aptRepo;
        }
        */

        // GET: Apartment
        public ActionResult Index(string searchTerm = null)
        {
            ApartmentViewModel avm = new ApartmentViewModel();
            avm.Apartments = _aptRepo.SearchApartments(searchTerm);
            return View(avm);
        }

        [HttpGet]
        public ActionResult AddApartment()
        {
            //return Content("Add page has not been written");
            ApartmentViewModel avm = new ApartmentViewModel();
            return View(avm);
        }

        [HttpPost]
        public ActionResult AddApartment(Apartment CurrentApt)
        {
            _aptRepo.AddApartment(CurrentApt);
            int AptID = _aptRepo.GetMaxAptID();
            return RedirectToAction("ApartmentDetails", new { AptID = AptID });
        }

        [HttpGet]
        public ActionResult ApartmentDetails(int AptID = 0)
        {
            if (AptID == 0) return RedirectToAction("Error", "Home");
            ApartmentViewModel avm = new ApartmentViewModel();
            avm.CurrentApt = _aptRepo.GetApartment(AptID);
            return View(avm);
        }

        [HttpGet]
        public ActionResult EditApartment(int AptID = 0)
        {
            if (AptID == 0) return RedirectToAction("Error", "Home");
            ApartmentViewModel avm = new ApartmentViewModel();
            avm.CurrentApt = _aptRepo.GetApartment(AptID);
            return View(avm);
        }

        [HttpPost]
        public ActionResult EditApartment(Apartment CurrentApt)
        {
            _aptRepo.UpdateApartment(CurrentApt);
            return RedirectToAction("ApartmentDetails", new { AptID = CurrentApt.AptID });
        }

        [HttpPost]
        public ActionResult SearchApartments(string SearchTerm)
        {
            IEnumerable<Apartment> apts = _aptRepo.SearchApartments(SearchTerm);
            return Content("No page has been written yet");
        }
    }
}