using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model.Model
{
    public class TourListModel
    {
        public PagedList.IPagedList<Tour> danhSach { get; set; }
        public PagedList.IPagedList<ImageTour> imageList;
        public string searchName = "";
        public List<string> listDiaDanh;
        private string searchDate;
        private string searchNumber;
        private int v;

        public TourListModel()
        {
            ImageDAO dao = new ImageDAO();
            imageList = dao.ListAll(1, 10);
        }

        public TourListModel(string _searchName)
        {
            searchName = _searchName;
            danhSach = TourDAO.searchByName(_searchName);
            ImageDAO dao = new ImageDAO();
            imageList = dao.ListAll(1,10);
            listDiaDanh = DiaDanhDAO.ListNameAll();
        }

        public TourListModel(string _searchName, string _searchDate, string _searchNumber)
        {
            this.searchName = _searchName;
            danhSach = TourDAO.searchByNameDateNumberPrice(_searchName, _searchDate, _searchNumber,0);
            ImageDAO dao = new ImageDAO();
            imageList = dao.ListAll(1, 10);
            listDiaDanh = DiaDanhDAO.ListNameAll();
        }

        public TourListModel(string _searchName, string _searchString, int type)
        {
            this.searchName = _searchName;
            if (type == 0) //searchDate
            {
                danhSach = TourDAO.searchByNameDatePrice(_searchName, _searchString, 0);
            }
            else if (type == 0) //searchNumber
            {
                danhSach = TourDAO.searchByNameNumberPrice(_searchName, _searchString , 0);
            }
            else if (type == 1)
            {
                
            }
            ImageDAO dao = new ImageDAO();
            imageList = dao.ListAll(1, 10);
            listDiaDanh = DiaDanhDAO.ListNameAll();

        }

        public TourListModel(string searchName, string searchDate, string searchNumber, int v)
        {
            this.searchName = searchName;
            this.searchDate = searchDate;
            this.searchNumber = searchNumber;
            this.v = v;
        }

        public TourListModel(string searchName, CommonConstants.type type, string searchDate, string searchNumber)
        {
            switch (type)
            {
                case CommonConstants.type.ZeroZero:
                    {
                        danhSach = TourDAO.searchByName(searchName);
                        break;
                    }
                case CommonConstants.type.ZeroTwo:
                    {
                        danhSach = TourDAO.searchByNamePrice(searchName, 2000000);
                        break;
                    }
                case CommonConstants.type.ZeroFour:
                    {
                        danhSach = TourDAO.searchByNamePrice(searchName, 4000000);
                        break;
                    }
                case CommonConstants.type.ZeroSix:
                    {
                        danhSach = TourDAO.searchByNamePrice(searchName, 6000000);
                        break;
                    }
                case CommonConstants.type.dateZero:
                    {
                        danhSach = TourDAO.searchByNameDatePrice(searchName, searchDate, 0);
                        break;
                    }
                case CommonConstants.type.dateTwo:
                    {
                        danhSach = TourDAO.searchByNameDatePrice(searchName, searchDate, 2000000);
                        break;
                    }
                case CommonConstants.type.dateFour:
                    {
                        danhSach = TourDAO.searchByNameDatePrice(searchName, searchDate, 4000000);
                        break;
                    }
                case CommonConstants.type.dateSix:
                    {
                        danhSach = TourDAO.searchByNameDatePrice(searchName, searchDate, 6000000);
                        break;
                    }
                case CommonConstants.type.numZero:
                    {
                        danhSach = TourDAO.searchByNameNumberPrice(searchName, searchNumber, 0);
                        break;
                    }
                case CommonConstants.type.numTwo:
                    {
                        danhSach = TourDAO.searchByNameNumberPrice(searchName, searchNumber, 2000000);
                        break;
                    }
                case CommonConstants.type.numFour:
                    {
                        danhSach = TourDAO.searchByNameNumberPrice(searchName, searchNumber, 4000000);
                        break;
                    }
                case CommonConstants.type.numSix:
                    {
                        danhSach = TourDAO.searchByNameNumberPrice(searchName, searchNumber, 6000000);
                        break;
                    }
                case CommonConstants.type.dateNumZero:
                    {
                        danhSach = TourDAO.searchByNameDateNumberPrice(searchName, searchDate, searchNumber, 0);
                        break;
                    }
                case CommonConstants.type.dateNumTwo:
                    {
                        danhSach = TourDAO.searchByNameDateNumberPrice(searchName, searchDate, searchNumber, 2000000);
                        break;
                    }
                case CommonConstants.type.dateNumFour:
                    {
                        danhSach = TourDAO.searchByNameDateNumberPrice(searchName, searchDate, searchNumber, 4000000);
                        break;
                    }
                case CommonConstants.type.dateNumSix:
                    {
                        danhSach = TourDAO.searchByNameDateNumberPrice(searchName, searchDate, searchNumber, 6000000);
                        break;
                    }
            }
            ImageDAO dao = new ImageDAO();
            imageList = dao.ListAll(1, 10);

        }
    }
}
