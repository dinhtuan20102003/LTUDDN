using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class GiaiptController : Controller
    {
        // GET: Giaipt
        public string bachai(double a = 0, double b = 1, double c = 1)
        {
            if (a == 0)
            {
                return "<h1 style='color: red; font-family: 'Times New Roman''>Hệ số a phải khác 0</h1>";
            }
            else
            {
                double delta = b * b - 4 * a * c;
                if (delta < 0)
                {
                    return $"<h1 style='color: red; font-family: 'Times New Roman''>Phương trình bậc 2: {a}x<sup>2</sup> + {b}x + {c} vô nghiệm.</h1>";
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    return $"<h1 style='color: aqua; font-family: 'Times New Roman''>Phương trình bậc 2: {a}x<sup>2</sup> + {b}x + {c} có nghiệm kép x<sub>1</sub> = x<sub>2</sub> = {x}</h1>";
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    return $"<h1 style='color: orange; font-family: 'Times New Roman''>Phương trình bậc 2: {a}x<sup>2</sup> + {b}x + {c} có hai nghiệm phân biệt </br>x<sub>1</sub> = {x1} </br> x<sub>2</sub> = {x2} </h1>";
                }
            }
        }
    }
}