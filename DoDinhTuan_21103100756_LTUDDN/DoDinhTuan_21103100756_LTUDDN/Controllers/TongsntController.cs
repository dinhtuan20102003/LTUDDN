using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_LTUDDN.Controllers
{
    public class TongsntController : Controller
    {
        // GET: Tongsnt
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Tongsnt(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                ViewBag.tb = "Không có số nào được nhập";

                return View();
            }

            var sont = a.Where(ktra).ToList();
            int tong = sont.Sum();

            ViewBag.tong = tong;
            ViewBag.sont = sont;
            ViewBag.a = a;
            return View();


        }
        private bool ktra(int a)
        {
            if (a < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}