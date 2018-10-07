using Model.DAO;
using Model.Entity;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TourModel model = new TourModel();
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            KhachHang entity = new KhachHang();
            entity.Email = Convert.ToString(form["khachHangModel.Email"]);
            entity.Password = Convert.ToString(form["khachHangModel.Password"]);
            entity = KhachHangDAO.checkLogin(entity.Email, entity.Password);
            Session.Add(Model.CommonConstants.USER,entity);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
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

    }
}