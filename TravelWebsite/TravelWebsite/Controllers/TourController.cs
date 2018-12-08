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
        public ActionResult Detail()
        {
            string code = "TOR2";
            DetailModel tour = new DetailModel(code);
            return View(tour);
        }
    }
}