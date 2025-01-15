﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class TimngayController : Controller
    {
        // GET: Timngay
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TimNgay(int thang=2, int nam=2024)
        {
            int ngay;

            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    ngay = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    ngay = 30;
                    break;
                case 2:
                   ngay = DateTime.IsLeapYear(nam) ? 29 : 28;
                    break;
                default:
                    throw new ArgumentException("Invalid month");
            }

            ViewBag.ngay = ngay;
            ViewBag.thang = thang;
            ViewBag.nam = nam;
            return View();
        }
    }
}