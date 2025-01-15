using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TuanDT.Controllers
{
    public class TuanController : Controller
    {
        // GET: Tuan
        public string Index()
        {
            return "Do Dinh Tuan <b>DT</>";
        }
        public string Welcome(string name, int Id = 1)
        {
            return HttpUtility.HtmlEncode("DHTI15A1CL " + name + ", NumTimes is: " + Id);
        }

    }
}