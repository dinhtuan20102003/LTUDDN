using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_LTUDDN.Controllers
{
    public class SohoanhaoController : Controller
    {
        // GET: Sohoanhao
        public ActionResult Sohoanhao(int n = 100)
        {
            ViewBag.n = n;
            var sohh = Timsohoanhao(n);
            ViewBag.sohh = sohh;
            return View();
        }
        private List<int> Timsohoanhao(int n)
        {
            var list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (LaSoHoanHao(i))
                {
                    list.Add(i);
                }
               
            }
            return list;
        }
        private bool LaSoHoanHao(int so)
        {
            int tong = 0;
            for (int i = 1; i <= so / 2; i++)
            {
                if (so % i == 0)
                {
                    tong += i;
                }
            }
            return tong == so;
        }
    }
}