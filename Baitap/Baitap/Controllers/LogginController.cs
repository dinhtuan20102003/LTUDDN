using Baitap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baitap.Controllers
{
    public class LogginController : Controller
    {
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
                    ViewBag.tb = "Đăng nhập thành công! Xin chào admin";
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoạc mật khẩu không đúng");
                }
            }
            return View(login);
        }
    }
}