using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;

namespace TravelWebsite.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail(string tourID)
        {
            DetailModel tour = new DetailModel(tourID);
            return View(tour);
        }

    }
}