using DoDinhTuan_21103100756_LTUDDN_BTVN_Tuan4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_Tuan4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid) {
                if (login.kiemtra())
                {
                    ViewBag.tb = "Bạn đã đăng nhập thành công! Xin chào admin";
                }
                else {
                    ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            return View(login);
        }
    }
}