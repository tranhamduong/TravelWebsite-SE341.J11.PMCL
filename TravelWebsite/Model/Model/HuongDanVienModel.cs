using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class HuongDanVienModel
    {
        public PagedList.IPagedList<HuongDanVien> danhSach { get; set; }
        public HuongDanVien huongDanVienModel;
        public List<string> dsHuongDanVien;

        public HuongDanVienModel()
        {
            huongDanVienModel = new HuongDanVien();
            HuongDanVienDAO dao = new HuongDanVienDAO();
            danhSach = dao.ListAll(1, 10);
            dsHuongDanVien = HuongDanVienDAO.ListNameAll();
        }
    }
}
