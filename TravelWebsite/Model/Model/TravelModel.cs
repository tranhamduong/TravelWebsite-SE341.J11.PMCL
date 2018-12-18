using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class TravelModel
    {
        public PhuongTienModel phuongTien;
        public HuongDanVienModel huongDanVien;
        public KhachHangModel khachHang;
        public TourModel tour;
        public ImageTourModel image;
        public DiaDanhModel diadanh;

        public List<string> dsHuongDanVien;
        public List<string> dsDiaDanh;
        public List<string> dsPhuongTien;

        public byte[] imageInternal;
        public byte[] imageExternal;

        public int internalTourCount = 0;
        public int externalTourCount = 0;

        public TravelModel()
        {
            phuongTien = new PhuongTienModel();
            huongDanVien = new HuongDanVienModel();
            khachHang = new KhachHangModel();
            diadanh = new DiaDanhModel();
            tour = new TourModel();
            image = new ImageTourModel();

            dsHuongDanVien = huongDanVien.dsHuongDanVien;
            dsDiaDanh = diadanh.dsDiaDanh;
            dsPhuongTien = phuongTien.dsPhuongTien;

            foreach (var item in phuongTien.danhSach)
            {
                item.MaPhuongTien = item.MaPhuongTien.Remove(0, 3);
            }

            foreach(var item in tour.danhSach)
            {
                if (item.isInternal == true)
                    internalTourCount++;
                else
                    externalTourCount++;
            }
        }
    }
}
