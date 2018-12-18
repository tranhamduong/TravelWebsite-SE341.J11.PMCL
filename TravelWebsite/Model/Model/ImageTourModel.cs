using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class ImageTourModel
    {
        public PagedList.IPagedList<ImageTour> danhSach { get; set; }
        public byte[] internalImage;
        public byte[] externalImage;

        public ImageTourModel()
        {
            ImageDAO dao = new ImageDAO();
            danhSach = dao.ListAll();
        }


    }
}
