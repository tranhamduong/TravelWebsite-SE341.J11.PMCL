using Model.DAO;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace TravelWebsite.Controllers
{
    public class SearchController : Controller
    {
            // GET: Admin/Search
            public ActionResult Index()
            {
                return View();
            }


        [HttpGet]
        public ActionResult Search(string searchName, string searchDate, string searchNumber)
        {
            List<string> dsDiaDanh = new List<string>();
            dsDiaDanh = DiaDanhDAO.ListNameAll();

            Session["dsDiaDanh"] = null;
            Session.Add("dsDiaDanh", dsDiaDanh);
            //list.danhSach = TourDAO.getSearchByName(searchName);

            TourListModel list;
            if (searchName == "Internal")
            {
                list = new TourListModel();
                list.danhSach = TourDAO.getInternalTourList();
            }
            else if (searchName == "External")
            {
                list = new TourListModel();
                list.danhSach = TourDAO.getExternalTourList();
            }
            else if (searchDate == null || searchNumber == null)
            {
                list = new TourListModel(searchName);
            }
            else
            {
                if (searchDate != "")
                {
                    if (searchNumber != "")//true/true
                    {
                        list = new TourListModel(searchName, searchDate, searchNumber);
                    }
                    else //true/false
                    {
                        list = new TourListModel(searchName, searchDate, 0);
                    }
                }
                else
                {
                    if (searchNumber != "") //false/true
                    {
                        list = new TourListModel(searchName, searchNumber, 1);
                    }
                    else // false/false
                    {
                        list = new TourListModel(searchName);
                    }
                }
            }
            
            return View(list);
        }

        [HttpGet]
        public ActionResult DetailSearch(string chonDiaDanh, string searchName, string price, string searchDate, string searchNumber)
        {
            TourListModel list = new TourListModel();
            List<string> dsDiaDanh = new List<string>();
            dsDiaDanh = DiaDanhDAO.ListNameAll();

            Session["dsDiaDanh"] = null;
            Session.Add("dsDiaDanh", dsDiaDanh);
            //list.danhSach = TourDAO.getSearchByName(searchName);

            if (searchDate != "")
            {
                if (searchNumber != "") //true/true
                {
                    if (price == null)
                        list = new TourListModel(searchName, CommonConstants.type.dateNumZero, searchDate, searchNumber);
                    else if (price == "2trieu")
                        list = new TourListModel(searchName, CommonConstants.type.dateNumTwo, searchDate, searchNumber);
                    else if (price == "4trieu")
                        list = new TourListModel(searchName, CommonConstants.type.dateNumFour, searchDate, searchNumber);
                    else
                        list = new TourListModel(searchName, CommonConstants.type.dateNumSix, searchDate, searchNumber);
                }
                else //true/false
                {
                    if (price == null)
                        list = new TourListModel(searchName, CommonConstants.type.dateZero, searchDate, searchNumber);
                    else if (price == "2trieu")                    
                        list = new TourListModel(searchName, CommonConstants.type.dateTwo, searchDate, searchNumber);
                    else if (price == "4trieu")
                        list = new TourListModel(searchName, CommonConstants.type.dateFour, searchDate, searchNumber);
                    else
                        list = new TourListModel(searchName, CommonConstants.type.dateSix, searchDate, searchNumber);
                }
            }
            else
            {
                if (searchNumber != "") //false/true
                {
                    if (price == null)
                        list = new TourListModel(searchName, CommonConstants.type.numZero, searchDate, searchNumber);
                    else if (price == "2trieu")
                        list = new TourListModel(searchName, CommonConstants.type.numTwo, searchDate, searchNumber);
                    else if (price == "4trieu")
                        list = new TourListModel(searchName, CommonConstants.type.numFour, searchDate, searchNumber);
                    else
                        list = new TourListModel(searchName, CommonConstants.type.numSix, searchDate, searchNumber);
                }
                else //false/false
                {
                    if (price == null)
                        list = new TourListModel(searchName, CommonConstants.type.ZeroZero, searchDate, searchNumber);
                    else if (price == "2trieu")
                        list = new TourListModel(searchName, CommonConstants.type.ZeroTwo, searchDate, searchNumber);
                    else if (price == "4trieu")
                        list = new TourListModel(searchName, CommonConstants.type.ZeroFour, searchDate, searchNumber);
                    else if (price == "6trieu")
                        list = new TourListModel(searchName, CommonConstants.type.ZeroSix, searchDate, searchNumber);

                }
            }
            return View(list);
        }
    }
}