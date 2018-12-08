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
        KhachHang khachHang;
        Tour tour;

        public ExportModel(KhachHang khachHang, Tour tour)
        {
            this.khachHang = khachHang;
            this.tour = tour;
        }

        public ExportModel()
        {
            this.khachHang = null;
            this.tour = null;
        }
    }
}
