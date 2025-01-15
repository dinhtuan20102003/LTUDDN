using DoDinhTuan_21103100756_LTUDDN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_LTUDDN.Controllers
{
    public class GiaiPTB2Controller : Controller
    {
        // GET: GiaiPTB2
        public ActionResult GiaiPTB2(PTB2 ptb2)
        {
            if (ptb2.A != 0)
            {
                double delta = ptb2.B * ptb2.B - 4 * ptb2.A * ptb2.C;
                if (delta > 0)
                {
                    double x1 = (-ptb2.B + Math.Sqrt(delta)) / (2 * ptb2.A);
                    double x2 = (-ptb2.B - Math.Sqrt(delta)) / (2 * ptb2.A);
                    ViewBag.kq = $"Phương trình có 2 nghiệm phân biệt: x<sub>1</sub> = {x1}, x<sub>2</sub> = {x2} ";
                }
                else if (delta == 0)
                {
                    double x = -ptb2.B / (2 * ptb2.A);
                    ViewBag.kq = $"Phương trình có nghiệm kép  x<sub>1</sub> =  x<sub>2</sub> ={x}";
                }
                else {
                    ViewBag.kq = "Phương trình vô nghiệm";
                }
            }
            else
            {
                ViewBag.kq = "Hệ số a phải khác 0";
            }
            return View();
        }
    }
}