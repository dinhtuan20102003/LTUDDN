using DoDinhTuan_21103100756_DHTI15A1CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
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
            if (ModelState.IsValid)
            {
                if (login.kiemtra())
                {
                    ViewBag.Message = "Bạn đã đăng nhập thành công! Xin chào Admin.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tên đăng nhập và mật khẩu.");
                  
                }
            }
            return View(login);
        }
    }
}