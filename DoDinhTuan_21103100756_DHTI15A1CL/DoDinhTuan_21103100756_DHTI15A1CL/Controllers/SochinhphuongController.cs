using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class SochinhphuongController : Controller
    {
     
        public ActionResult Sochinhphuong(string soNhap)
        {
            var soChinhPhuong = new List<int>();

            if (!string.IsNullOrEmpty(soNhap))
            {
                var mangSo = soNhap.Split(',');

                foreach (var so in mangSo)
                {
                    if (int.TryParse(so.Trim(), out int ketQua))
                    {
                        var canhBacHai = (int)Math.Sqrt(ketQua);
                        if (ketQua == canhBacHai * canhBacHai)
                        {
                            soChinhPhuong.Add(ketQua);
                        }
                    }
                }
            }

            ViewBag.SoChinhPhuong = soChinhPhuong;
            return View();
        }
    }
}