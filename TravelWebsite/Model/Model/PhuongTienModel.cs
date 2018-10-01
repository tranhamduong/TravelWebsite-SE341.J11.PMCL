using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public  class PhuongTienModel
    {
        public PagedList.IPagedList<PhuongTien> danhSach { get; set; }
        public PhuongTien phuongTienModel ;
        public List<string> dsPhuongTien;

        public PhuongTienModel()
        {
            phuongTienModel = new PhuongTien();
            PhuongTienDAO dao = new PhuongTienDAO();
            danhSach = dao.ListAll(1,10);
            dsPhuongTien = dao.ListNameAll();
        }
    }
}
