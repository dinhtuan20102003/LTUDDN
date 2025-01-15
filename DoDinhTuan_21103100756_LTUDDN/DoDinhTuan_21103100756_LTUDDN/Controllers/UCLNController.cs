using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_LTUDDN.Controllers
{
    public class UCLNController : Controller
    {
        // GET: UCLN
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UCLN(int a = 5, int b = 6)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            int ucln;
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
                ucln = a;
            }
            ViewBag.ucln = a;
            return View();
        }
    }
}