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
            TravelModel travel = new TravelModel();
            if (Session["InternalTourPR"] == null || Session["ExternalTourPR"] == null)
            {
                Session.Add("InternalTourPR", ThamSoDAO.getInternalPR().Trim());
                Session.Add("ExternalTourPR", ThamSoDAO.getExternalPR().Trim());
            }
            else
            {
                Session["InternalTourPR"] = ThamSoDAO.getInternalPR();
                Session["ExternalTourPR"] = ThamSoDAO.getExternalPR();
            }
                
            return View(travel);
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

            var success = KhachHangDAO.checkLogin(entity.Email, entity.Password);

            if (success != null) //login success
            {
                Session.Add(Model.CommonConstants.USER, success);
                return RedirectToAction("Index", "Home");

            }
            else //login failed
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Search(string searchName, string searchDate, string searchNumber)
        {
           TourListModel list = new TourListModel();
            
           list.danhSach = TourDAO.getSearchByName(searchName);

            return View(list);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(KhachHang khachHang)
        {
            KhachHangDAO dao = new KhachHangDAO();
            dao.insert(khachHang);

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