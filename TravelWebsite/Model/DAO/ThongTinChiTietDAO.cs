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
                entity.MaChiTietTour = "CT" + code;
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
    }
}
