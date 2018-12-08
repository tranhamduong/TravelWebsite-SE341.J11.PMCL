using Model.DAO;
using Model.Model;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelWebsite.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult ExportCheckout()
        {
            return View();
        }

        public ActionResult ExportCheckout(string maKhachHang, string maTour)
        {
            
            ExportModel model = new ExportModel(KhachHangDAO.getByCode(maKhachHang), TourDAO.getByCode(maTour));
            return View(model);
        }

        [HttpPost]
        public ActionResult exportToPDF()
        {
            string header = "";
            string footer = "";

            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--footer-spacing \"0\" " +
                                   "--footer-font-size \"0\" " +
                                   "--header-font-size \"0\" " +
                                   "--margin-left \"0\" " +
                                   "--margin-right \"0\" " +
                                   "--margin-top \"0\" " +
                                   "--margin-bottom \"0\" ", header, footer);

            ViewAsPdf vap = new PartialViewAsPdf();
            vap.CustomHeaders = null;
            vap.CustomSwitches = customSwitches;
            vap.PageMargins = new Rotativa.Options.Margins(0, 0, 0, 0);
            vap.PageSize = Rotativa.Options.Size.A4;
            vap.ViewName = "Checkout";
            vap.PageOrientation = Rotativa.Options.Orientation.Portrait;
            vap.ContentDisposition = Rotativa.Options.ContentDisposition.Attachment;
            vap.FileName = "Report.pdf";

            return vap;
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}