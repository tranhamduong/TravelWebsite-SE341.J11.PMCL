using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class TourModel
    {
        public PagedList.IPagedList<Tour> danhSach { get; set; }
        public Tour tour;
        public ThongTinChiTietTour chiTietTour;

        public TourModel()
        {
            tour = new Tour();
            chiTietTour = new ThongTinChiTietTour();
            TourDAO dao = new TourDAO();
            danhSach = dao.ListAll(1, 10);
        }
    }
}
