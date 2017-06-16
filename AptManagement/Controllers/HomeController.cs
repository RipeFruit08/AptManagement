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
    public class HomeController : Controller
    {
        IApartmentRepo _aptRepo;

        public HomeController()
        {
            AppDataContext Context = new AppDataContext();
            _aptRepo = new ApartmentRepo(Context);
        }

        public ActionResult Index()
        {
            Apartment apt = _aptRepo.GetApartment(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}