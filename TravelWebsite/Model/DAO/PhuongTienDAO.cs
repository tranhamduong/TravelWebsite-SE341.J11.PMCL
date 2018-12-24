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
    public class PhuongTienDAO : BaseDAO
    {
        public PhuongTienDAO()
        {
            db = new Entity.TravelDatabase();
        }

        public bool insert(PhuongTien entity)
        {
            try
            {
                entity.MaPhuongTien = "PTN" + entity.MaPhuongTien;
                db.PhuongTiens.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public override bool Delete(string key)
        {
            var target = db.PhuongTiens.SingleOrDefault(x => x.MaPhuongTien == key);
            db.PhuongTiens.Remove(target);
            return base.Delete(key);
        }

        public IPagedList<PhuongTien> ListAll(int page = 1, int pageSize = 10)
        {
            var model = db.PhuongTiens.Where(x => x.isDeleted == null).OrderBy(x => x.MaPhuongTien).ToPagedList(1, 20);
            return model;
        }

        public static List<string> ListNameAll()
        {
            db = new TravelDatabase();
            List<string> temp = db.PhuongTiens.Where(x => x.isDeleted == null).Select(x => x.MaPhuongTien).ToList();
            for (int i = 0;i < temp.Count(); i++)
            {
                temp[i] = temp[i].Remove(0,3);
            }
            return temp;
        }

        public static bool delete(string key)
        {
            db = new TravelDatabase();
            var pt = db.PhuongTiens.Where(x => x.MaPhuongTien.Trim() == key).FirstOrDefault();
            pt.isDeleted = true;
            db.SaveChanges();
            return false;
        }

        public static bool edit (PhuongTien entity)
        {
            db = new TravelDatabase();
            var pt = db.PhuongTiens.Where(x => x.MaPhuongTien.Trim() == entity.MaPhuongTien).FirstOrDefault();
            pt.TenSanBay = entity.TenSanBay;
            pt.ThoiGianDen = entity.ThoiGianDen;
            pt.ThoiGianDi = entity.ThoiGianDi;
            db.SaveChanges();
            return false;
        }
    }
}
