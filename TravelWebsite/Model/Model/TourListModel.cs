using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class TourListModel
    {
        public PagedList.IPagedList<Tour> danhSach { get; set; }

        public TourListModel()
        {

        }

        public TourListModel(string stringSearch)
        {
            danhSach = TourDAO.getSearchByName(stringSearch);
        }
    }
}
