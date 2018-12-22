using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PhieuDatTourDAO : BaseDAO
    {
        public PhieuDatTourDAO()
        {
            db = new TravelDatabase();
        }

        public string Insert(string maTour, string maKhachHang, string hoTenKhachThamGia, int soGheNguoiLon, int soGheTreEm, int soPhongDon, string tongTien)
        {
            PhieuDatTour pdt = new PhieuDatTour();

            pdt.MaTour = maTour;
            pdt.MaKhachHang = maKhachHang;
            pdt.KhachThamGia = hoTenKhachThamGia;
            pdt.soGheNguoiLon = soGheNguoiLon;
            pdt.soGheTreEm = soGheTreEm;
            pdt.soPhongDon = soPhongDon;
            pdt.TongTien = tongTien;
            int code = generateCode() + 1;
            pdt.MaPDT = "PDT" + code;

            db.PhieuDatTours.Add(pdt);
            db.SaveChanges();

            return pdt.MaPDT;
        }

        public int generateCode()
        {
            return db.PhieuDatTours.Count();
        }

        public static PhieuDatTour getByCode(string maKhachHang, string maTour)
        {
            db = new TravelDatabase();
            var entity = db.PhieuDatTours.Where(x => x.MaTour == maTour && x.MaKhachHang == maKhachHang).FirstOrDefault();
            return entity;
        }

        public static bool checkIfExistedByCode(string maPDT)
        {
            db = new TravelDatabase();
            PhieuDatTour pdt = db.PhieuDatTours.Where(x => x.MaPDT == maPDT).FirstOrDefault();
            if (pdt == null)
                return false;
            return true;
        }

        public static PhieuDatTour getByCode2(string maPDT)
        {
            db = new TravelDatabase();
            return db.PhieuDatTours.Where(x => x.MaPDT == maPDT).FirstOrDefault();
        }
    }
}
