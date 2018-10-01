using Model.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO 
{
    public class HuongDanVienDAO : BaseDAO
    {
        public HuongDanVienDAO()
        {
            db = new TravelDatabase();
        }

        public CommonConstants.error_code insert(HuongDanVien entity)
        {
            try
            {
                var result = db.HuongDanViens.SingleOrDefault(x => x.HoTenHDV == entity.HoTenHDV);
                if (result != null && result.SoDienThoaiHDV == entity.SoDienThoaiHDV )
                    return CommonConstants.error_code.already_exists;
                int code = generateCode() + 1;
                entity.MaHuongDanVien = "HDV" + code.ToString();
                db.HuongDanViens.Add(entity);
                db.SaveChanges();
                return CommonConstants.error_code.success;
            }
            catch
            {
                return CommonConstants.error_code.ureadable_data;
            }
        }

        public override bool Delete(string key)
        {

            return base.Delete(key);
        }

        public IPagedList<HuongDanVien> ListAll(int page = 1, int pageSize = 10)
        {
            var model = db.HuongDanViens.OrderBy(x => x.MaHuongDanVien).ToPagedList(page, pageSize);
            return model;
        }

        public int generateCode()
        {
            return db.HuongDanViens.Count();
        }

        public List<string> ListNameAll()
        {
            return db.HuongDanViens.Select(x => x.HoTenHDV).ToList();
        }
    }
}
