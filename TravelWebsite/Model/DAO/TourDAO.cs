using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;

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
                entity.MaTour = "TOUR" + code.ToString();
                db.Tours.Add(entity);
                db.SaveChanges();
                return CommonConstants.error_code.success;
            }
            catch (Exception e) {
                return CommonConstants.error_code.ureadable_data;
            }
            return CommonConstants.error_code.default_error;
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
    }
}
