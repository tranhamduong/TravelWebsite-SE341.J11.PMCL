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
                var result = db.KhachHangs.SingleOrDefault(x => x.SoHoChieuCMND == entity.SoHoChieuCMND);
                if (result != null)
                    return CommonConstants.error_code.already_exists;
                int code = generateCode() + 1;
                entity.MaKhachHang = "KH" + code.ToString();
                entity.Password = "Abc12345";
                db.KhachHangs.Add(entity);
                db.SaveChanges();
                return CommonConstants.error_code.success;
            }
            catch
            {
                return CommonConstants.error_code.ureadable_data;
            }
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
                    if (entity.Password == result.Password.ToString().Trim())
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
            var model = db.KhachHangs.OrderBy(x => x.MaKhachHang).ToPagedList(page, pageSize);
            return model;
        }

        public int generateCode()
        {
            return db.KhachHangs.Count();
        }
    }
}
