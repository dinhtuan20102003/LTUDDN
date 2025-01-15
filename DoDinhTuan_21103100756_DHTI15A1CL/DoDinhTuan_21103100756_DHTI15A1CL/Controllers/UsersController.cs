using DoDinhTuan_21103100756_DHTI15A1CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class UsersController : Controller
    {
        public static List<user1> user1 = new List<user1>
        {
            new user1{Id = 1, Name = "Tuấn", Address = "Thanh Hóa", Email="namtuan216@gmail.com", Password= "123456", Birthday = new DateTime(2000, 8, 3), Gender = true},
            new user1{Id = 2, Name = "Dũng", Address = "Hà Nội", Email="namtuan216@gmail.com", Password= "123456", Birthday = new DateTime(2000, 8, 3), Gender = true},
            new user1{Id = 3, Name = "Linh", Address = "Thanh Hóa", Email="namtuan216@gmail.com", Password= "123456", Birthday = new DateTime(2000, 8, 3), Gender = false},

        };
        // GET: Users
        public ActionResult Index()
        {
            return View(user1);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var user = user1.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(user1 newUser)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    newUser.Id = user1.Max(u => u.Id) + 1;
                    user1.Add(newUser);
                    return RedirectToAction("Index");
                }
                return View(newUser);
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            var user = user1.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, user1 updateUser)
        {
            try
            {
                // TODO: Add update logic here
                var user = user1.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                else if (ModelState.IsValid)
                {
                    user.Name = updateUser.Name;
                    user.Address = updateUser.Address;
                    user.Email = updateUser.Email;
                    user.Password = updateUser.Password;
                    user.Gender = updateUser.Gender;
                    user.Birthday = updateUser.Birthday;
                    user.Age = DateTime.Now.Year - user.Birthday.Year;
                    return RedirectToAction("Index");
                }
                return View(updateUser);
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            var user = user1.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var user = user1.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    user1.Remove(user);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
