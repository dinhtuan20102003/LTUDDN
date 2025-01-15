using DoDinhTuan_21103100756_DHTI15A1CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class DemoViewController : Controller
    {
        // GET: DemoView
        // dùng layout mặc định
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KhongDungLayout()
        {
            //return View("Index");
            return View("~/Views/Home/About.cshtml");
        }

        public ActionResult TruyenDuLieu()
        {
            ViewData["HoTen"] = "Đỗ Đình Tuấn";
            ViewBag.QueQuan = "Thanh Hóa";
            TempData["Tuoi"] = 21;
            return View();
            // RedirectToAction("Index");
        }
        public ActionResult Giaiptbac1(decimal a = 1, decimal b = 2)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            return View();
        }

        public ActionResult SoChan(int[] a)
        {
            ViewBag.a = a;
            return View();
        }

        public ActionResult NhanDL(user1 u)
        {
            string msg = $"{u.Id}</br> {u.Name}</br> {u.Address}</br> {u.Email}</br> {u.Gender}</br> {u.Password}</br>";
            return Content(msg);
        }

        public ActionResult TruyenDuLieuDoiTuongUser()
        {
            var user = new user1();
            user.Id = 1;
            user.Name = "Tuấn";
            user.Address = "Thanh Hóa";
            user.Email = "namtuan216@gmail.com";
            user.Gender = false;
            user.Password = string.Empty;
           // ViewBag.user = user;
            return View(user);
        }

        public ActionResult TruyenTapDoiTuongUsers()
        {
            var users = new List<user1> {
                new Models.user1 { Id =1, Name = "DinhTuan", Address = "Thanh Hoa", Email = "namtuan216@gmail.com"},
                new Models.user1 { Id =2, Name = "TuanDT", Address = "Thanh Hoa", Email = "dodinhtuan20102003@gmail.com"},
                new Models.user1 { Id =3, Name = "DoTuan", Address = "Thanh Hoa", Email = "tuando20102003@gmail.com"},
           };
            //ViewBag.users = users;
            return View(users);
        }

    }
}