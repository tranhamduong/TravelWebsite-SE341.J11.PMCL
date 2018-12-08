using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ThongTinChiTietDAO : BaseDAO
    {
        public ThongTinChiTietDAO()
        {
            db = new TravelDatabase();
        }

        public CommonConstants.error_code insert(ThongTinChiTietTour entity)
        {
            try
            {
                int code = generateCode() + 1;
                entity.MaChiTietTour = "CTT" + code;
                db.ThongTinChiTietTours.Add(entity);
                db.SaveChanges();
                return CommonConstants.error_code.success;
            }catch (Exception e)
            {
                return CommonConstants.error_code.ureadable_data;
            }
            return CommonConstants.error_code.default_error;
        }

        public int generateCode()
        {
            return db.ThongTinChiTietTours.Count();
        }

        public static ThongTinChiTietTour getByCode(string code)
        {
            db = new TravelDatabase();
            return db.ThongTinChiTietTours.Where(x => x.MaChiTietTour == code).FirstOrDefault();
        }

        public void EditTourDone(ThongTinChiTietTour ctt)
        {
            db = new TravelDatabase();

            ThongTinChiTietTour chiTietTour = db.ThongTinChiTietTours.FirstOrDefault(x => x.MaChiTietTour == ctt.MaChiTietTour);
            chiTietTour.NgayGioTapTrung = ctt.NgayGioTapTrung;
            chiTietTour.NoiTapTrung = ctt.NoiTapTrung;
            chiTietTour.CoBaoHiem = ctt.CoBaoHiem;
            chiTietTour.QuaTang = ctt.QuaTang;
            chiTietTour.LichTrinh = ctt.LichTrinh;
            chiTietTour.MaPhuongTien = ctt.MaPhuongTien;
            
            db.SaveChanges();
        }
    }
}
