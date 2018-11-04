using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelWebsite.Areas.Admin.Controllers
{
    public class EditController : Controller
    {
        // GET: Admin/Edit
       
        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            string temp = Convert.ToString(form["ma"]);
            int type = getTypeOf(temp.Substring(0, 3));
            if (type == 1)
            {
                HuongDanVienDAO.delete(temp.Trim());
            }
            else if (type == 4)
            {
                DiaDanhDAO.delete(temp.Trim());
            }
            else if (type == 5)
            {
                KhachHangDAO.delete(temp.Trim());
            }
            else if (type == 7)
            {
                PhuongTienDAO.delete(temp.Trim());
            }
            return RedirectToAction("InsertData", "Insert");
        }

        [HttpPost]
        public ActionResult EditDD(FormCollection form)
        {
            string a = Convert.ToString(form["ma"]);
            string b = Convert.ToString(form["tenEdited"]);
            string c = Convert.ToString(form["soKhachEdited"]);
            return RedirectToAction("InsertData", "Insert");
        }

        public ActionResult EditHDV(FormCollection form)
        {
            return RedirectToAction("InsertData", "Insert");
        }

        public ActionResult EditPTN(FormCollection form)
        {
            return RedirectToAction("InsertData", "Insert");
        }

        public ActionResult EditKHG(FormCollection form)
        {
            return RedirectToAction("InsertData", "Insert");
        }


        public int getTypeOf(string code)
        {
            switch (code)
            {
                case "HDV":
                    {
                        return 1;
                    }
                case "TOR":
                    {
                        return 2;
                    }
                case "CTT":
                    {
                        return 3;
                    }
                case "DDD":
                    {
                        return 4;
                    }
                case "KHG": {
                        return 5;
                    }
                case "PTN":
                    {
                        return 7;
                    }
                default:
                    {
                        return 99;
                    }
            }   
        }
    }
}