using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_LTUDDN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult NhapLieuBT_UCLN()
        {
            return View();
        }
        public ActionResult TimUCLN(int a, int b)
        {

            string msg = $"UCLN của {a} và {b} là: ";
            while (a != b)
            {
                if (a > b)
                {

                    a = a - b;
                }
                else
                {
                    b = b - a;
                }

            }
            msg +=  $"{a}";
            return Content(msg);
        }
    }
}