using DoDinhTuan_21103100756_DHTI15A1CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class GiaiPTB2Controller : Controller
    {
        // GET: GiaiPTB2
        public ActionResult GiaiPTB2(PTB2 ptb2)
        {
            //var ptb2 = new PTB2();
            //ptb2.A = 1;
            //ptb2.B = 5;
            //ptb2.C = 6 ;
            if (ptb2.A != 0)
            {
                double delta = ptb2.B * ptb2.B - 4 *  ptb2.A *   ptb2.C;
                if (delta > 0)
                {
                    double x1 = (-ptb2.B + Math.Sqrt(delta)) / (2 * ptb2.A);
                    double x2 = (-ptb2.B - Math.Sqrt(delta)) / (2 * ptb2.A);
                    ViewBag.Result = $"Phương trình có 2 nghiệm phân biệt: x<sub>1</sub> = {x1}, x<sub>2</sub> = {x2}";
                }
                else if (delta == 0)
                {
                    double x = -ptb2.B / (2 * ptb2.A);
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