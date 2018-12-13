using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DAO;
using Model.Entity;

namespace Model.Model
{

    public class DetailModel
    {
        public Tour tour;
        public ThongTinChiTietTour chiTietTour;
        public HuongDanVien hdv;
        public DiaDanh diadanh;
        public ImageTour image;

        public DetailModel(string code)
        {
            try
            {
                tour = TourDAO.getByCode(code);
                chiTietTour = ThongTinChiTietDAO.getByCode(tour.MaChiTietTour);
                hdv = HuongDanVienDAO.getByName(tour.MaHuongDanVien);
                diadanh = DiaDanhDAO.getByName(tour.MaDiaDanh);
                image = ImageDAO.getById(tour.MaTour);
            }
            catch(Exception e)
            {
                return;
            }
            
        }
    }
}
