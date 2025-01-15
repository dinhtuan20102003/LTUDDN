using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class UCLNController : Controller
    {
        // GET: UCLN
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UCLN(int a = 1, int b = 2)
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