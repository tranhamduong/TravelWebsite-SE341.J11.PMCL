using Model;
using Model.DAO;
using Model.Entity;
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
        [HttpGet]
        public ActionResult Index(string tourID)
        {
            ExportModel model = null;
            KhachHang khachHang = new KhachHang();
            khachHang = (KhachHang)Session[Model.CommonConstants.USER];
            if (khachHang == null)
            {
                model = new ExportModel(TourDAO.getByCode(tourID));
            }
            else
                model = new ExportModel(khachHang, TourDAO.getByCode(tourID));
            return View(model);
        }

        // GET: Business
        [HttpGet]
        public ActionResult ExportCheckout(ExportModel model)
        {
            if (model.Filter == 0)
            {
                int count = model.pdt.soGheNguoiLon + model.pdt.soGheTreEm ;
                DiaDanhDAO.tangSoLuong(model.tour.MaDiaDanh, count);

                TourDAO.xepCho(model.tour.MaTour, count);

                return View(model);
            }
            else if (model.Filter == 1)
            {
                return View(model);
            }
            else 
            {
                return View("NotExistingTour");
            }
        }

        [HttpGet]
        public ActionResult NotExistingTour()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Confirm(FormCollection form, string tourID, string khachHangID, string tongTienGiaTri)
        {
            int flag = 0;
            KhachHang khachHang = new KhachHang();
            khachHang.HoTenKhachHang = form["inputHoTen"];
            khachHang.Email = form["inputEmail"];
            khachHang.SoDienThoaiKH = form["inputMobileNumber"];
            khachHang.SoHoChieuCMND = form["inputCMND"];
            khachHang.DiaChi = form["inputAddress"];

            KhachHangDAO dao = new KhachHangDAO();
            string khachHangNewId = "KHG" + (dao.generateCode() + 1);

            if (khachHangID != null && khachHangID != "") //khach da dang nhap
            {
                dao.editByEmail(khachHang);
                khachHangNewId = dao.getCodeByEmail(khachHang.Email);
                flag = 1;
            }
            else // khach vang lai
            {
                dao.insert(khachHang);
                flag = 0;
            }

            ExportModel model;
            PhieuDatTourDAO phieuDatTourDAO = new PhieuDatTourDAO();
            string code = phieuDatTourDAO.Insert(tourID, khachHangNewId, form["customerNameArray"], Int32.Parse(form["inputNumberOfOlder"]), Int32.Parse(form["inputNumberOfYounger"]), Int32.Parse(form["inputNumberOfSingleRoom"]), tongTienGiaTri.ToString());
            if (flag == 0)
            {
                model = ExportModel.getModel(KhachHangDAO.getByCode(khachHangNewId), TourDAO.getByCode(tourID));
            }
            else
            {
                model = ExportModel.getModelNew(KhachHangDAO.getByCode(khachHangNewId), TourDAO.getByCode(tourID), code);
            }

            int count = model.pdt.soGheNguoiLon + model.pdt.soGheTreEm;
            DiaDanhDAO.tangSoLuong(model.tour.MaDiaDanh, count);

            TourDAO.xepCho(model.tour.MaTour, count);


            return View("ExportCheckout", model);
        }

        [HttpPost]
        public ActionResult exportToPDF()
        {
            string header = "";
            string footer = "";

            KhachHang a = (KhachHang)Session[Model.CommonConstants.USER];
            Tour b = new Tour();

            ExportModel c = new ExportModel(a, b);

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
            vap.Model = c;
            vap.PageOrientation = Rotativa.Options.Orientation.Portrait;
            vap.ContentDisposition = Rotativa.Options.ContentDisposition.Attachment;

            vap.FileName = "Report.pdf";

            return vap;
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult checkBookedTour(string maPDT, string emailKH)
        {
            ExportModel model;
            if (PhieuDatTourDAO.checkIfExistedByCode(maPDT)) //ton tai pdt nay
            {
                if (KhachHangDAO.getByCode((PhieuDatTourDAO.getByCode2(maPDT).MaKhachHang)).Email == emailKH) //trung email
                {
                    model = new ExportModel(KhachHangDAO.getByCode((PhieuDatTourDAO.getByCode2(maPDT).MaKhachHang)), TourDAO.getByCode(PhieuDatTourDAO.getByCode2(maPDT).MaTour));
                    model.pdt = PhieuDatTourDAO.getByCode2(maPDT);
                    
                    return View("ExportCheckout", model);
                }
            }
            

            model = new ExportModel();
            model.Filter = 2;
            return View("NotExistingTour");
        }
    }
}