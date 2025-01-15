using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TuanDT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Đỗ Đình Tuấn.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Trường Đại Học Kinh Tế Kỹ Thuật Công Nghiệp";

            return View();
        }
    }
}