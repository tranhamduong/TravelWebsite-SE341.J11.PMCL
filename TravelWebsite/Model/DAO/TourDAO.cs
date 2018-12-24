using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;
using Model.Model;

namespace Model.DAO
{
    public class TourDAO : BaseDAO
    {
        public TourDAO()
        {
            db = new TravelDatabase();
        }
        public CommonConstants.error_code insert(Tour entity)
        {
            int code = generateCode();
            try
            {
                entity.MaTour = "TOR" + code.ToString();
                db.Tours.Add(entity);
                db.SaveChanges();
                return CommonConstants.error_code.success;
            }
            catch (Exception e) {
                return CommonConstants.error_code.ureadable_data;
            }
            return CommonConstants.error_code.default_error;
        }

        public static IPagedList<Tour> searchByName(string stringSearch)
        {
            
            var model = db.Tours.OrderBy(x => x.MoTaTour).Where(x => x.MoTaTour.Contains(stringSearch)).ToPagedList(1, 20);

            return model;
        }

        public static IPagedList<Tour> searchByNamePrice(string stringSearch, int price)
        {
            if (price == 0)
                return db.Tours.OrderBy(x => x.MoTaTour).Where(x => x.MoTaTour.Contains(stringSearch)).ToPagedList(1, 20);
            else
                return db.Tours.OrderBy(x => x.MoTaTour).Where(x => x.MoTaTour.Contains(stringSearch) && x.GiaTien < price).ToPagedList(1, 20);
        }

        public static void xepCho(string maTour, int soCho)
        {
            db = new TravelDatabase();
            var tour = db.Tours.Where(x => x.MaTour == maTour).FirstOrDefault();
            tour.SoChoConLai -= soCho;
            if (tour.SoChoConLai <= 0)
            {
                tour.SoChoConLai = 0;
                tour.TinhTrang = false;
            }

            db.SaveChanges();
        }

        public static IPagedList<Tour> searchByNameDateNumberPrice(string searchName, string searchDate, string searchNumber, int price)
        {
            DateTime date = new DateTime();
            date = DateTime.Parse(searchDate);
            DateTime fromDate = date.AddDays(-3);
            DateTime toDate = date.AddDays(3);
            int count = Int32.Parse(searchNumber);
            if (price == 0)
                return db.Tours.OrderBy(x => x.MaTour).Where(x => x.MoTaTour.Contains(searchName) && x.SoChoConLai >= count && (x.NgayKhoiHanh >= fromDate && x.NgayKhoiHanh <= toDate)).ToPagedList(1, 20);
            else
                return db.Tours.OrderBy(x => x.MaTour).Where(x => x.MoTaTour.Contains(searchName) && x.SoChoConLai >= count && (x.NgayKhoiHanh >= fromDate && x.NgayKhoiHanh <= toDate) && x.GiaTien < price).ToPagedList(1, 20);
        }

        public static Tour getByCode(string code)
        {
            db = new TravelDatabase();
            var tour = db.Tours.Where(x => x.MaTour == code).FirstOrDefault();
            return tour;
        }

        public static IPagedList<Tour> searchByNameDatePrice(string searchName, string searchString, int price)
        {
            DateTime date = new DateTime();
            date = DateTime.Parse(searchString);
            DateTime fromDate = date.AddDays(-3);
            DateTime toDate = date.AddDays(3);
            if (price == 0)
                return db.Tours.OrderBy(x => x.MaTour).Where(x => x.MoTaTour.Contains(searchName) && (x.NgayKhoiHanh >= fromDate && x.NgayKhoiHanh <= toDate)).ToPagedList(1,20);
            else
                return db.Tours.OrderBy(x => x.MaTour).Where(x => x.MoTaTour.Contains(searchName) && (x.NgayKhoiHanh >= fromDate && x.NgayKhoiHanh <= toDate) && x.GiaTien < price).ToPagedList(1, 20);
        }

        public static IPagedList<Tour> searchByNameNumberPrice(string searchName, string searchString, int price)
        {
            int count = Int32.Parse(searchString);

            if (price == 0)
                return db.Tours.OrderBy(x => x.MaTour).Where(x => x.MoTaTour.Contains(searchName) && x.SoChoConLai >= count).ToPagedList(1,20);
            else
                return db.Tours.OrderBy(x => x.MaTour).Where(x => x.MoTaTour.Contains(searchName) && x.SoChoConLai >= count && x.GiaTien < price).ToPagedList(1, 20);
        }

        public override bool Delete(string key)
        {
            return base.Delete(key);
        }

        public IPagedList<Tour> ListAll(int page = 1, int pageSize = 20)
        {
            var model = db.Tours.OrderBy(x => x.MaTour).Where(x=>x.isDeleted == null).ToPagedList(page, pageSize);
            return model;
        }

        public IPagedList<Tour> ListAllGiamGia(int page = 1, int pageSize = 20)
        {
            var model = db.Tours.OrderByDescending(x => x.GiamGia).Where(x=>x.isDeleted == null).ToPagedList(1, 20);
            return model;
        }

        public int generateCode()
        {
            return db.Tours.Count();
        }

        public static bool delete(string key)
        {
            db = new TravelDatabase();
            var tour = db.Tours.Where(x => x.MaTour.Trim() == key).FirstOrDefault();
            tour.isDeleted = true;
            db.SaveChanges();
            return false;
        }

        public bool EditTourDone(Tour _tour)
        {
            var tour = db.Tours.Where(x => x.MaTour.Trim() == _tour.MaTour).FirstOrDefault();
            if (tour != null)
            {
                tour.MaTour = _tour.MaTour;
                tour.MoTaTour = _tour.MoTaTour;
                tour.NgayKhoiHanh = _tour.NgayKhoiHanh;
                tour.NgayTroVe = _tour.NgayTroVe;
                tour.SoNgay = _tour.SoNgay;
                tour.SoChoConLai = _tour.SoChoConLai;
                tour.TinhTrang = _tour.TinhTrang;
                tour.GiaTien = _tour.GiaTien;
                tour.GiaTienTreEm = _tour.GiaTienTreEm;
                tour.GiamGia = _tour.GiamGia;
                tour.MaChiTietTour = _tour.MaChiTietTour.Trim();
                tour.MaDiaDanh = _tour.MaDiaDanh;
                tour.PhuongTien = _tour.PhuongTien;
                tour.NoiKhoiHanh = _tour.NoiKhoiHanh;
                db.SaveChanges();
                return true;
            }
            else
                return false;
            
        }

        public static IPagedList<Tour> getExternalTourList()
        {
            db = new TravelDatabase();
            return db.Tours.OrderBy(x => x.MaTour).Where(x => x.isInternal == false && x.isDeleted == null).ToPagedList(1, 20);
        }

        public static IPagedList<Tour> getInternalTourList()
        {
            db = new TravelDatabase();
            return db.Tours.OrderBy(x => x.MaTour).Where(x => x.isInternal == true  && x.isDeleted == null).ToPagedList(1, 20);
        }

        public static Tour getRandomTourBeside()
        {
            db = new TravelDatabase();
            Random ran = new Random();
            TourDAO dao = new TourDAO();
            int count = dao.generateCode();
            string maTour;
            do
            {
                maTour = "TOR" + ran.Next(0, count);
            } while (maTour == "TOR4");
            var entity = db.Tours.Where(x => x.MaTour == maTour).FirstOrDefault();

            return entity;
        }
    }
}
