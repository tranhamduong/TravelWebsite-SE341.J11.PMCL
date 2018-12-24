using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.DAO
{
    public class KhachHangDAO : BaseDAO
    {
        public KhachHangDAO() {
            db = new TravelDatabase();
        }

        public CommonConstants.error_code insert(KhachHang entity)
        {
            try
            {
                var result = db.KhachHangs.SingleOrDefault(x => x.Email == entity.Email);
                if (result != null)
                    return CommonConstants.error_code.already_exists;
                int code = generateCode() + 1;
                entity.MaKhachHang = "KHG" + code.ToString();
                if (entity.Password == null)
                    entity.Password = CommonConstants.defaultPassword;
                entity.isAdmin = false;
                db.KhachHangs.Add(entity);
                db.SaveChanges();
                return CommonConstants.error_code.success;
            }
            catch
            {
                return CommonConstants.error_code.ureadable_data;
            }
        }

        public static KhachHang getByCode(string maKhachHang)
        {
            db = new TravelDatabase();
            KhachHang kh = db.KhachHangs.FirstOrDefault(x=>x.MaKhachHang == maKhachHang);
            return kh;
        }

        public static KhachHang checkLogin(string email, string password)
        {
            db = new TravelDatabase();
            try
            {
                var result = db.KhachHangs.SingleOrDefault(x => x.Email == email && x.Password == password);
                if (result != null)
                {
                    return result;
                }
            }catch(Exception e) { }
            return null;
        }

        public CommonConstants.error_code login(KhachHang entity)
        {
            try
            {
                var result = db.KhachHangs.SingleOrDefault(x => x.TenDangNhap == entity.TenDangNhap);
                if (result == null)
                    return CommonConstants.error_code.not_found_username ;
                else {
                    if (entity.Password == result.Password.ToString().Trim() && entity.isDeleted == true)
                    {

                        return CommonConstants.error_code.success;
                    }
                    else
                    {
                        return CommonConstants.error_code.not_correct_password;
                    }
                }
            }
            catch (Exception e)
            {
                return CommonConstants.error_code.unknow_error;
            }
        }

        public string getCodeByEmail(string email)
        {
            return db.KhachHangs.Where(x => x.Email == email).FirstOrDefault().MaKhachHang;
        }

        public static void register(KhachHang khachHang)
        {
            db = new TravelDatabase();
            db.KhachHangs.Add(khachHang);


        }

        public bool update(KhachHang entity)
        {
            return false;
        }

        public override bool Delete(string key)
        {
            return base.Delete(key);
        }

        public IPagedList<KhachHang> ListAll(int page = 1, int pageSize = 10)
        {
            var model = db.KhachHangs.Where(x => x.isDeleted == null).OrderBy(x => x.MaKhachHang).ToPagedList(1, 20);
            return model;
        }

        public int generateCode()
        {
            return db.KhachHangs.Count();
        }

        public static bool delete(string key)
        {
            db = new TravelDatabase();
            var kh = db.KhachHangs.Where(x => x.MaKhachHang.Trim() == key).FirstOrDefault();
            kh.isDeleted = true;
            db.SaveChanges();
            return false;
        }

        public static bool edit (KhachHang entity)
        {
            db = new TravelDatabase();
            var kh = db.KhachHangs.Where(x => x.MaKhachHang == entity.MaKhachHang).FirstOrDefault();
            kh.HoTenKhachHang = entity.HoTenKhachHang;
            kh.Email = entity.Email;
            kh.SoDienThoaiKH = entity.SoDienThoaiKH;
            kh.SoHoChieuCMND = entity.SoHoChieuCMND;
            kh.DiaChi = entity.DiaChi;
            kh.TenDangNhap = entity.TenDangNhap;
            db.SaveChanges();
            return false;
        }

        public bool editByEmail(KhachHang entity)
        {
            var kh = db.KhachHangs.Where(x => x.Email == entity.Email).FirstOrDefault();
            kh.HoTenKhachHang = entity.HoTenKhachHang;
            kh.Email = entity.Email;
            kh.SoDienThoaiKH = entity.Email;
            kh.SoHoChieuCMND = entity.SoHoChieuCMND;
            kh.DiaChi = entity.DiaChi;
            //kh.TenDangNhap = entity.TenDangNhap;
            db.SaveChanges();
            return false;
        }

    }
}
