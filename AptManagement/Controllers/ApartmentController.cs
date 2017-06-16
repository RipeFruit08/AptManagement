using AptManagement.Data.Context.Dapper.Config;
using AptManagement.Data.Context.Dapper.Repos;
using AptManagement.Data.IRepos;
using AptManagement.Data.Models;
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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddApartment()
        {
            return Content("Add page has not been written");
        }

        [HttpPost]
        public ActionResult SearchApartments(string SearchTerm)
        {
            return Content("No page has been written yet");
        }
    }
}