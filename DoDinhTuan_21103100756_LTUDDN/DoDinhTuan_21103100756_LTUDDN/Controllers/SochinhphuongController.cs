using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_LTUDDN.Controllers
{
    public class SochinhphuongController : Controller
    {
        // GET: Sochinhphuong
        public ActionResult Sochinhphuong(string number)
        {
            var socp = new List<int>();
            if (!string.IsNullOrWhiteSpace(number))
            {
                var mang = number.Split(',');
                foreach (var so in mang)
                {
                    if(int.TryParse(so.Trim(), out int ketQua))
                    {
                        var sqrt = (int)Math.Sqrt(ketQua);
                        if(ketQua == sqrt*  sqrt)
                        {
                            socp.Add(ketQua);
                        }
                    }
                }
            }
            ViewBag.socp = socp;
            return View();
        }
    }
}