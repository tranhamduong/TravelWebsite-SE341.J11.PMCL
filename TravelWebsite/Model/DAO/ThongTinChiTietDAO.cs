using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
            db.SaveChanges();
        }
    }
}
