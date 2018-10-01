using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class KhachHangModel
    {
        public PagedList.IPagedList<KhachHang> danhSach { get; set; }
        public KhachHang khachHangModel;

        public KhachHangModel()
        {
            khachHangModel = new KhachHang();
            KhachHangDAO dao = new KhachHangDAO();
            danhSach = dao.ListAll(1, 10);
        }
    }
}
