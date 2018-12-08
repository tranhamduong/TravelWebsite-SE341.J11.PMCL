using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class EditTourModel
    {
        public Tour tour;
        public List<string> dsHuongDanVien;
        public List<string> dsDiaDanh;
        public List<string> dsPhuongTien;
        public ThongTinChiTietTour thongTinChiTietTour;

        public EditTourModel(string ma)
        {
            tour = TourDAO.getByCode(ma);
            thongTinChiTietTour = ThongTinChiTietDAO.getByCode(tour.MaChiTietTour);
            dsDiaDanh = DiaDanhDAO.ListNameAll();
            dsHuongDanVien = HuongDanVienDAO.ListNameAll();
            dsPhuongTien = PhuongTienDAO.ListNameAll();
        }

        public EditTourModel()
        {

        }

    }
}
