using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class Gptbac2Controller : Controller
    {
        // GET: Gptbac2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Gptbac2(int a=0, int b = 0, int c = 0)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;
            if (a != 0)
            {
                double delta = b * b - 4 * a * c;
                if (delta > 0)
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    ViewBag.Result = $"Phương trình có 2 nghiệm phân biệt: x<sub>1</sub> = {x1}, x<sub>2</sub> = {x2}";
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    ViewBag.Result = $"Phương trình có nghiệm kép: x = {x}";
                }
                else
                {
                    ViewBag.Result = "Phương trình vô nghiệm.";
                }
            }
            else
            {
                ViewBag.Result = "Giá trị a không thể bằng 0.";
            }

            return View();
        }
    }
}