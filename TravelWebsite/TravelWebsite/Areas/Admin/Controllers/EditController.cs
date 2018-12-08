using Model.DAO;
using Model.Entity;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelWebsite.Areas.Admin.Controllers
{
    public class EditController : Controller
    {
        // GET: Admin/Edit

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            string temp = Convert.ToString(form["ma"]);
            int type = 0;
            if (temp.Length >= 3)
            {
                type = getTypeOf(temp.Substring(0, 3));
                if (type == 1)
                {
                    HuongDanVienDAO.delete(temp.Trim());
                }
                else if (type == 4)
                {
                    DiaDanhDAO.delete(temp.Trim());
                }
                else if (type == 5)
                {
                    KhachHangDAO.delete(temp.Trim());
                }
                else if (type == 7)
                {
                    PhuongTienDAO.delete(temp.Trim());
                }
                else if (type == 99)
                {
                    temp = "PTN" + temp;
                    PhuongTienDAO.delete(temp.Trim());
                }
                else if (type == 2)
                {
                    TourDAO.delete(temp.Trim());
                }
            }
            else
            {
                temp = "PTN" + temp;
                PhuongTienDAO.delete(temp.Trim());
            } 
            return RedirectToAction("InsertData", "Insert");
        }


        [HttpPost]
        public ActionResult EditTour(FormCollection form)
        {
            string a = Convert.ToString(form["ma"]);
            EditTourModel model = new EditTourModel(a);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTourDone(FormCollection form)
        {
            TourDAO dao = new TourDAO();
            Tour tour = new Tour();
            tour.MoTaTour = form["tour.MoTaTour"];
            tour.SoChoConLai = Convert.ToInt32(form["tour.SoChoConLai"]);
            tour.NgayKhoiHanh = DateTime.Parse(Convert.ToString(form["thoigiandi"]));
            tour.NgayTroVe = DateTime.Parse(Convert.ToString(form["thoigianden"]));
            tour.SoNgay = Convert.ToDouble(form["tour.SoNgay"]);
            tour.GiamGia = Convert.ToInt32(form["tour.GiamGia"]);
            tour.GiaTien = Convert.ToInt32(form["tour.GiaTien"]);
            tour.GiaTienTreEm = Convert.ToInt32(form["tour.GiaTienTreEm"]);
            tour.MaHuongDanVien = form["tour.MaHuongDanVien"];
            tour.MaDiaDanh = form["tour.MaDiaDanh"];
            tour.PhuongTien = form["tour.PhuongTien"];
            string a = form["tour.PhuongTien"];
            tour.NoiKhoiHanh = form["tour.NoiKhoiHanh"];
            tour.MaTour = form["tour.MaTour"];
            tour.MaChiTietTour = form["tour.MaChiTietTour"];

            dao.EditTourDone(tour);

            ThongTinChiTietDAO dao2 = new ThongTinChiTietDAO();
            ThongTinChiTietTour ctt = new ThongTinChiTietTour();
            ctt.MaChiTietTour = tour.MaChiTietTour.Trim();
            ctt.LichTrinh = form["lichtrinh"];
            ctt.NoiTapTrung = form["noitaptrung"];
            ctt.NgayGioTapTrung = DateTime.Parse(Convert.ToString(form["ngaygiotaptrung"]));
            ctt.MaPhuongTien = tour.PhuongTien;
            if (Convert.ToString(form["baohiem"]) == "Có")
                ctt.CoBaoHiem = true;
            else ctt.CoBaoHiem = false;
            ctt.QuaTang = form["nuocsuoi"] + "|" + form["non"] + "|" + form["aothun"] + "|" + form["du"];

            dao2.EditTourDone(ctt);

            return RedirectToAction("InsertData", "Insert");
        }

        [HttpGet]
        public ActionResult EditTourDetail(FormCollection form)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditDD(FormCollection form)
        {
            string a = Convert.ToString(form["ma"]);
            string b = Convert.ToString(form["tenEdited"]);
            string c = Convert.ToString(form["soKhachEdited"]);
            return RedirectToAction("InsertData", "Insert");
        }

        public ActionResult EditHDV(FormCollection form)
        {
            return RedirectToAction("InsertData", "Insert");
        }

        public ActionResult EditPTN(FormCollection form)
        {
            return RedirectToAction("InsertData", "Insert");
        }

        public ActionResult EditKHG(FormCollection form)
        {
            return RedirectToAction("InsertData", "Insert");
        }

        [HttpPost]
        public ActionResult editPR(FormCollection form)
        {
            string type = form["type"];
            string id = form["value"];
            if (type == "internal")
            {
                Session["InternalTourPR"] = id;
                ThamSoDAO.setInternalPR(id);
            }
            else
            {
                Session["ExternalTourPR"] = id;
                ThamSoDAO.setExternalPR(id);
            }

            return RedirectToAction("InsertData", "Insert");
        }

        public int getTypeOf(string code)
        {
            switch (code)
            {
                case "HDV":
                    {
                        return 1;
                    }
                case "TOR":
                    {
                        return 2;
                    }
                case "CTT":
                    {
                        return 3;
                    }
                case "DDD":
                    {
                        return 4;
                    }
                case "KHG": {
                        return 5;
                    }
                case "PTN":
                    {
                        return 7;
                    }
                default:
                    {
                        return 99;
                    }
            }   
        }
    }
}