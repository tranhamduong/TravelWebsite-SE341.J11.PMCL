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

        public static IPagedList<Tour> getSearchByName(string stringSearch)
        {
            var model = db.Tours.OrderBy(x => x.MoTaTour).Where(x => x.MoTaTour.Contains(stringSearch)).ToPagedList(1, 10);

            return model;
        }

        public static Tour getByCode(string code)
        {
            db = new TravelDatabase();
            var tour = db.Tours.Where(x => x.MaTour == code).FirstOrDefault();
            return tour;
        }

        public override bool Delete(string key)
        {
            return base.Delete(key);
        }

        public IPagedList<Tour> ListAll(int page = 1, int pageSize = 10)
        {
            var model = db.Tours.OrderBy(x => x.MaTour).ToPagedList(page, pageSize);
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
    }
}
