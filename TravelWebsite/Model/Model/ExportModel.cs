using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class ExportModel
    {
        public KhachHang khachHang;
        public Tour tour;
        public PhieuDatTour pdt;
        public string VISACharge = "0";
        public int tongTien = 0;
        public int tongTienTreEm = 0;
        public int Filter;
        

        public ExportModel(KhachHang khachHang, Tour tour)
        {
            this.khachHang = khachHang;
            this.tour = tour;
            this.VISACharge =ThamSoDAO.getVISACharge();

            if (tour != null)
            {
                tongTien = tour.GiaTien - (tour.GiaTien / 100 * (int)tour.GiamGia); //Giam Gia
                tongTienTreEm = tour.GiaTienTreEm - (tour.GiaTienTreEm / 100 * (int)tour.GiamGia);
            }
        }

        public ExportModel(KhachHang khachHang, Tour tour, int type)
        {
            this.khachHang = khachHang;
            this.tour = tour;
            this.VISACharge = ThamSoDAO.getVISACharge();
            this.Filter = 1;

            if (tour != null)
            {
                this.tongTien = tour.GiaTien - tour.GiaTien / 100 * (int)tour.GiamGia;
                this.tongTienTreEm = tour.GiaTien - tour.GiaTien / 100 * (int)tour.GiamGia;
            }
        }

        public ExportModel(Tour tour)
        {
            this.khachHang = new KhachHang();
            this.tour = tour;
            this.VISACharge = ThamSoDAO.getVISACharge();
            

            if (tour != null)
            {
                this.tongTien = tour.GiaTien - tour.GiaTien / 100 * (int)tour.GiamGia;
                this.tongTienTreEm = tour.GiaTien - tour.GiaTien / 100 * (int)tour.GiamGia;
            }
        }

        public ExportModel()
        {
            this.khachHang = null;
            this.tour = null;
        }

        public static ExportModel getModel(KhachHang kh, Tour tour)
        {
            ExportModel model = new ExportModel();
            model.tour = tour;
            model.khachHang = kh;
            model.VISACharge = ThamSoDAO.getVISACharge();
            model.pdt = PhieuDatTourDAO.getByCode(kh.MaKhachHang, tour.MaTour);

            model.tongTien = tour.GiaTien - tour.GiaTien / 100 * (int)tour.GiamGia;
            model.tongTienTreEm = tour.GiaTien - tour.GiaTien / 100 * (int) tour.GiamGia;

            return model;
        }

        public static ExportModel getModelNew(KhachHang kh, Tour tour, string maPDT)
        {
            ExportModel model = new ExportModel();
            model.tour = tour;
            model.khachHang = kh;
            model.VISACharge = ThamSoDAO.getVISACharge();
            if (PhieuDatTourDAO.getByCode(kh.MaKhachHang,tour.MaTour) != null) //da ton tai lich su dung tour nay truoc day
            {
                model.pdt = PhieuDatTourDAO.getByCode2(maPDT);
            }
            return model;
        }
    }
}
