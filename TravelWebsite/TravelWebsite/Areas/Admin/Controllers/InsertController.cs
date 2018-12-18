using Model.Entity;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using TravelWebsite.Areas.Admin.Controllers;
using System.Drawing;

namespace TravelWebsite.Areas.Admin
{
    public class InsertController : BaseController
    {
        // GET: Admin/Insert
        public ActionResult InsertData()
        {
            TravelModel model = new TravelModel();
            return View(model); 
        }

        [HttpPost]
        public ActionResult themPhuongTien(FormCollection form)
        {
            PhuongTien dto = new PhuongTien();
            DateTime time = DateTime.Parse(Convert.ToString(form["thoigiandi"]));
            dto.ThoiGianDi = time;
            time = DateTime.Parse(Convert.ToString(form["thoigianden"])) ;
            dto.ThoiGianDen = time;
            dto.MaPhuongTien = Convert.ToString(form["phuongTien.phuongTienModel.MaPhusongTien"]);
            dto.TenSanBay = Convert.ToString(form["phuongTien.phuongTienModel.TenSanBay"]);

            try
            {
                PhuongTienDAO dao = new PhuongTienDAO();
                dao.insert(dto);
            }catch (Exception e)
            {

            }
            return RedirectToAction("InsertData");
        }

        public ActionResult themHuongDanVien(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                HuongDanVien dto = new HuongDanVien();
                dto.HoTenHDV = Convert.ToString(form["huongDanVien.huongDanVienModel.HoTenHDV"]);
                dto.SoDienThoaiHDV = Convert.ToString(form["huongDanVien.huongDanVienModel.SoDienThoaiHDV"]);
                try
                {
                    HuongDanVienDAO dao = new HuongDanVienDAO();
                    dao.insert(dto);
                }
                catch (Exception e) { }

                return RedirectToAction("InsertData");
            }
            else
                return RedirectToAction("InsertData");

        }
        public ActionResult themKhachHang(FormCollection form)
        {
            KhachHang dto = new KhachHang();
            dto.HoTenKhachHang = Convert.ToString(form["khachHang.khachHangModel.HoTenKhachHang"]);
            dto.Email = Convert.ToString(form["khachHang.khachHangModel.Email"]);
            dto.SoDienThoaiKH = Convert.ToString(form["khachHang.khachHangModel.SoDienThoaiKH"]);
            dto.SoHoChieuCMND = Convert.ToString(form["khachHang.khachHangModel.SoHoChieuCMND"]);
            dto.TenDangNhap = Convert.ToString(form["khachHang.khachHangModel.TenDangNhap"]);

            try
            {
                KhachHangDAO dao = new KhachHangDAO();
                dao.insert(dto);
            }
            catch (Exception e) { }

            return RedirectToAction("InsertData");
        }

        public ActionResult themTour(FormCollection form)
        {
            Tour dto1 = new Tour();
            ThongTinChiTietTour dto2 = new ThongTinChiTietTour();

            dto1.MoTaTour = Convert.ToString(form["tour.tour.MoTaTour"]);
            dto1.SoChoConLai = Convert.ToInt16(form["tour.tour.SoChoConLai"]);
            
            dto1.NgayKhoiHanh = DateTime.Parse(Convert.ToString(form["thoigiandi"])); 
            dto1.NgayTroVe = DateTime.Parse(Convert.ToString(form["thoigianden"]));
            dto1.GiaTien = Convert.ToInt32(form["tour.tour.GiaTien"]);
            dto1.GiaTienTreEm = Convert.ToInt32(form["tour.tour.GiaTienTreEm"]);
            if (Convert.ToString(form["tour.tour.TinhTrang"]) == "Mở")
                dto1.TinhTrang = true;
            else dto1.TinhTrang = false;
            dto1.SoNgay = Convert.ToDouble(form["tour.tour.SoNgay"]);
            string temp = Convert.ToString(form["giamgia"]);
            temp = temp.Remove(temp.Length - 1);
            dto1.GiamGia = Convert.ToDouble(temp);
            dto1.MaHuongDanVien = Convert.ToString(form["tour.tour.MaHuongDanVien"]);
            dto1.MaDiaDanh = Convert.ToString(form["tour.tour.MaDiaDanh"]);

            //dto2 binding
            dto2.MaPhuongTien = Convert.ToString(form["tour.chiTietTour.MaPhuongTien"]);
            dto2.NgayGioTapTrung = DateTime.Parse(Convert.ToString(form["ngaygiotaptrung"]));
            if (Convert.ToString(form["baohiem"]) == "Có")
                dto2.CoBaoHiem = true;
            else dto2.CoBaoHiem = false;
            dto2.LichTrinh = Convert.ToString(form["tour.chiTietTour.LichTrinh"]);
            dto2.NoiTapTrung = Convert.ToString(form["tour.chiTietTour.NoiTapTrung"]);
            dto2.QuaTang = form["nuocsuoi"] + "|" + form["non"] + "|" + form["aothun"] + "|" + form["du"];

            try
            {
                TourDAO dao1 = new TourDAO();
                ThongTinChiTietDAO dao2 = new ThongTinChiTietDAO();
                dao2.insert(dto2);
                dto1.MaChiTietTour = "CTT" + dao2.generateCode();
                
                dao1.insert(dto1);
                
            }catch (Exception e) { }
            return RedirectToAction("InsertData");
        }

        public ActionResult themDiaDanh(FormCollection form)
        {
            DiaDanh dto = new DiaDanh();
            dto.MoTaDiaDanh = Convert.ToString(form["diadanh.diaDanhModel.MoTaDiaDanh"]);
            dto.DiaDanhConTieuBieu = Convert.ToString(form["diadanh.diaDanhModel.DiaDanhConTieuBieu"]);
            string temp = Convert.ToString(form["diadanh.diaDanhModel.MaVungMien"]);
            switch (temp)
            {
                case "Miền_Bắc": { dto.MaVungMien = 1; break;}
                case "Miền_Trung": { dto.MaVungMien = 2; break; }
                case "Miền_Nam": { dto.MaVungMien = 3; break; }
                case "Nước_Ngoài": { dto.MaVungMien = 4; break; }
                default: { dto.MaVungMien = 1; break; }
            }
            dto.TenDiaDanh = Convert.ToString(form["diadanh.diaDanhModel.TenDiaDanh"]);
            try
            {
                DiaDanhDAO dao = new DiaDanhDAO();
                dao.Insert(dto);
            }catch (Exception e) { }
            return RedirectToAction("InsertData");
        }

        [HttpPost]
        public ActionResult themAnhTour(HttpPostedFileBase pictureOne, HttpPostedFileBase pictureTwo, HttpPostedFileBase pictureThree, string maTour,  FormCollection form)
        {
            if (pictureOne == null || pictureTwo == null || pictureThree == null)
            {
                return RedirectToAction("InsertData");
            }
            else
            {
                //resize anh ve 1200x700
                var rPictureOne = Image.FromStream(pictureOne.InputStream, true, true);
                Image resizedPictureOne = ScaleImage(rPictureOne, Model.CommonConstants.tour_image_height);

                var rPictureTwo = Image.FromStream(pictureTwo.InputStream, true, true);
                Image resizedPictureTwo = ScaleImage(rPictureTwo, Model.CommonConstants.tour_image_height);

                var rPictureThree = Image.FromStream(pictureThree.InputStream, true, true);
                Image resizedPictureThree = ScaleImage(rPictureThree, Model.CommonConstants.tour_image_height);

                //luu du lieu vao chuoi byte
                ImageConverter converter = new ImageConverter();
                byte[] arrayPictureOne = (byte[]) converter.ConvertTo(resizedPictureOne, typeof(byte[]));

                byte[] arrayPictureTwo = (byte[])converter.ConvertTo(resizedPictureTwo, typeof(byte[]));

                byte[] arrayPictureThree = (byte[])converter.ConvertTo(resizedPictureThree, typeof(byte[]));

                bool res = false;
                ImageDAO.Delete(maTour);
                res = ImageDAO.Insert(arrayPictureOne, arrayPictureTwo, arrayPictureThree, maTour);
                //res = ImageDAO.InsertOne(arrayPictureOne, maTour);
            }
            return RedirectToAction("InsertData");
        }

        [HttpPost]
        public ActionResult themAnhDiaDanh(HttpPostedFileBase picture, string maDiaDanh) 
        {
            if (picture != null)
            {
                var rPictureOne = Image.FromStream(picture.InputStream, true, true);
                Image resizedPictureOne = ScaleImage(rPictureOne, Model.CommonConstants.tour_image_height);

                ImageConverter converter = new ImageConverter();
                byte[] arrayPictureOne = (byte[])converter.ConvertTo(resizedPictureOne, typeof(byte[]));

                bool res = false;
                DiaDanhDAO.DeleteAnh(maDiaDanh);
                res = DiaDanhDAO.InsertAnh(arrayPictureOne, maDiaDanh);
            }
            return RedirectToAction("InsertData");
        }

        public static Image ScaleImage(Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;   

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }        
    }
}