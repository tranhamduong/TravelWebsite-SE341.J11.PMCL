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
        public DiaDanhModel diadanh;
        public List<string> dsHuongDanVien;
        public List<string> dsDiaDanh;
        public List<string> dsPhuongTien;

        public TravelModel()
        {
            phuongTien = new PhuongTienModel();
            huongDanVien = new HuongDanVienModel();
            khachHang = new KhachHangModel();
            diadanh = new DiaDanhModel();
            tour = new TourModel();
            dsHuongDanVien = huongDanVien.dsHuongDanVien;
            dsDiaDanh = diadanh.dsDiaDanh;
            dsPhuongTien = phuongTien.dsPhuongTien;

            foreach (var item in phuongTien.danhSach)
            {
                item.MaPhuongTien = item.MaPhuongTien.Remove(0, 3);
            }
        }
    }
}
