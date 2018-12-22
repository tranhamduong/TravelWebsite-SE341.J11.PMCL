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

        public Tour relativeTour1;
        public Tour relativeTour2;
        public Tour relativeTour3;

        public byte[] relativeTourImage1;
        public byte[] relativeTourImage2;
        public byte[] relativeTourImage3;

        public DetailModel(string code)
        {
            try
            {
                tour = TourDAO.getByCode(code);
                chiTietTour = ThongTinChiTietDAO.getByCode(tour.MaChiTietTour);
                hdv = HuongDanVienDAO.getByName(tour.MaHuongDanVien);
                diadanh = DiaDanhDAO.getByName(tour.MaDiaDanh);
                image = ImageDAO.getById(tour.MaTour);

                do
                {
                    relativeTour1 = TourDAO.getRandomTourBeside();
                    if (relativeTour1 != null)
                        relativeTourImage1 = ImageDAO.getOneImage(relativeTour1.MaTour);
                } while (relativeTour1 == null || relativeTour1.MaTour == tour.MaTour);

                do
                {
                    relativeTour2 = TourDAO.getRandomTourBeside();
                    if (relativeTour2 != null)
                        relativeTourImage2 = ImageDAO.getOneImage(relativeTour2.MaTour);
                } while (relativeTour2 == null || relativeTour2.MaTour == tour.MaTour || relativeTour2.MaTour == relativeTour1.MaTour);

                do
                {
                    relativeTour3 = TourDAO.getRandomTourBeside();
                    if (relativeTour3 != null)
                        relativeTourImage3 = ImageDAO.getOneImage(relativeTour3.MaTour);
                } while (relativeTour3 == null || relativeTour3.MaTour == tour.MaTour || relativeTour3.MaTour == relativeTour1.MaTour || relativeTour3.MaTour == relativeTour2.MaTour);


            }
            catch(Exception e)
            {
                return;
            }
            
        }
    }
}
