﻿using Model.Entity;
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

        public static void tangSoLuong(string tenDiaDanh, int count)
        {
            db = new TravelDatabase();
            DiaDanh dd = new DiaDanh();
            dd = db.DiaDanhs.Where(x => x.TenDiaDanh == tenDiaDanh).FirstOrDefault();
            dd.SoKhachDaThamQuan += count;
            db.SaveChanges();
        }

        public IPagedList<DiaDanh> ListAll(int page = 1, int pageSize = 20)
        {
            var model = db.DiaDanhs.Where(x => x.isDeleted == null).OrderBy(x => x.TenDiaDanh).ToPagedList(1, 20);
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

        public static void DeleteAnh(string maDiaDanh)
        {
            db = new TravelDatabase();
            var model = db.DiaDanhs.FirstOrDefault(x => x.MaDiaDanh == maDiaDanh);
            if (model != null)
            {
                model.Anh = null;
                db.SaveChanges();
            }
        }

        public static bool InsertAnh(byte[] arrayPictureOne, string maDiaDanh)
        {
            db = new TravelDatabase();
            var model = db.DiaDanhs.FirstOrDefault(x => x.MaDiaDanh == maDiaDanh);
            if (model != null)
            {
                model.Anh = arrayPictureOne;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
