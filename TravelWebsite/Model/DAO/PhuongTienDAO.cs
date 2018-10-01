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
            var model = db.PhuongTiens.OrderBy(x => x.MaPhuongTien).ToPagedList(page, pageSize);
            return model;
        }

        public List<string> ListNameAll()
        {
            return db.PhuongTiens.Select(x => x.MaPhuongTien).ToList();
        }
    }
}
