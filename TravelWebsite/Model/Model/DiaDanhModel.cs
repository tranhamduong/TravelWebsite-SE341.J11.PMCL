using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class DiaDanhModel
    {
        public PagedList.IPagedList<DiaDanh> danhSach { get; set; }
        public DiaDanh diaDanhModel;
        public List<string> dsDiaDanh;

        public DiaDanhModel()
        {
            diaDanhModel = new DiaDanh();
            DiaDanhDAO dao = new DiaDanhDAO();
            danhSach = dao.ListAll(1, 10);
            dsDiaDanh = dao.ListNameAll();
        }
    }
}
