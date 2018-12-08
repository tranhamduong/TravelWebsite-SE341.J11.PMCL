using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace Model.DAO
{
    public class DiaDanhDAO : BaseDAO
    {
        public DiaDanhDAO()
        {
            db = new TravelDatabase();
        }

        public CommonConstants.error_code Insert(DiaDanh entity)
        {
            try
            {
                var result = db.DiaDanhs.SingleOrDefault(x => x.TenDiaDanh == entity.TenDiaDanh);
                if (result != null)
                    return CommonConstants.error_code.already_exists;
                int code = generateCode() + 1;
                entity.MaDiaDanh = "DDD" + code.ToString();
                entity.SoKhachDaThamQuan = 0;
                db.DiaDanhs.Add(entity);
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
        public IPagedList<DiaDanh> ListAll(int page = 1, int pageSize = 10)
        {
            var model = db.DiaDanhs.Where(x => x.isDeleted == null).OrderBy(x => x.TenDiaDanh).ToPagedList(page, pageSize);
            return model;
        }

        public int generateCode()
        {
            return db.DiaDanhs.Count();
        }
        public static List<string> ListNameAll()
        {
            db = new TravelDatabase();
            return db.DiaDanhs.Where(x => x.isDeleted == null).Select(x => x.TenDiaDanh).ToList();
        }

        public static bool delete(string key)
        {
            db = new TravelDatabase();
            var dd = db.DiaDanhs.Where(x => x.MaDiaDanh.Trim() == key).FirstOrDefault();
            dd.isDeleted = true;
            db.SaveChanges();
            return false;
        }

        public static bool edit(DiaDanh entity)
        {
            db = new TravelDatabase();
            var dd = db.DiaDanhs.Where(x => x.MaDiaDanh == entity.MaDiaDanh).FirstOrDefault();
            dd.MoTaDiaDanh = entity.MoTaDiaDanh;
            dd.SoKhachDaThamQuan = entity.SoKhachDaThamQuan;
            dd.TenDiaDanh = entity.TenDiaDanh;
            dd.MaVungMien = entity.MaVungMien;
            db.SaveChanges();
            return false;
        }

        public static DiaDanh getByName(string tenDiaDanh)
        {
            db = new TravelDatabase();
            DiaDanh dd = db.DiaDanhs.Where(x => x.TenDiaDanh == tenDiaDanh).FirstOrDefault();
            string code = "";
            if (dd != null)
                code = dd.MaDiaDanh;
            if (code != "")
                return db.DiaDanhs.Where(x => x.MaDiaDanh == code).FirstOrDefault();
            return null;
        }
    }
}
