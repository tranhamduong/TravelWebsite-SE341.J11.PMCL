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

            travel.imageInternal = ImageDAO.getOneImage(ThamSoDAO.getInternalPR().Trim());
            travel.imageExternal = ImageDAO.getOneImage(ThamSoDAO.getExternalPR().Trim());

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
                if (success.isAdmin == true)
                {
                    Session.Add(Model.CommonConstants.USER, success);
                    Session.Add("isAdmin","true");
                }
                else
                {
                    Session.Add(Model.CommonConstants.USER, success);
                }
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

    }
}