using DDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDT.Controllers
{
    public class TacGiasController : Controller
    {
        // GET: TacGias
        public static List<TacGia> tacgias = new List<TacGia>
        {
            new TacGia{MaTG = 1, HoTen = "Do Dinh Tuan", DT = "0987546216", Email = "namtuan216@gmail.com", NgaySinh = new DateTime(2003, 8,3), DonVi = "DHSPKTHU"},
            new TacGia{MaTG = 2, HoTen = "Do Dinh Khoi", DT = "0987546216", Email = "namtuan216@gmail.com", NgaySinh = new DateTime(2003, 8,3), DonVi = "DHSPKTHU"}

        };
        public ActionResult Index()
        {
            return View(tacgias);
        }

        // GET: TacGias/Details/5
        public ActionResult Details(int id)
        {
            var tacgia = tacgias.FirstOrDefault(u => u.MaTG == id);
            if (tacgia == null)
            {
                return HttpNotFound();
            }
            return View(tacgia);
        }

        // GET: TacGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TacGias/Create
        [HttpPost]
        public ActionResult Create(TacGia newTacGia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newTacGia.MaTG = tacgias.Max(u => u.MaTG) + 1;
                    tacgias.Add(newTacGia);
                    return RedirectToAction("Index");
                }
                return View(newTacGia);

            }
            catch
            {
                return View();
            }
        }

        // GET: TacGias/Edit/5
        public ActionResult Edit(int id)
        {
            var tacgia = tacgias.FirstOrDefault(u => u.MaTG == id);
            if (tacgia == null)
            {
                return HttpNotFound();
            }
            return View(tacgia);
        }

        // POST: TacGias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TacGia updateTacGia)
        {
            try
            {
                var tacgia = tacgias.FirstOrDefault(u => u.MaTG == id);
                if (tacgia == null)
                {
                    return HttpNotFound();
                }
                else if (ModelState.IsValid) {
                   
                    tacgia.HoTen = updateTacGia.HoTen;
                    tacgia.DT = updateTacGia.DT;
                    tacgia.Email = updateTacGia.Email;
                    tacgia.NgaySinh = updateTacGia.NgaySinh;
                    tacgia.DonVi = updateTacGia.DonVi;
                    return RedirectToAction("Index");
                }
                return View(updateTacGia);

            }
            catch
            {
                return View();
            }
        }

        // GET: TacGias/Delete/5
        public ActionResult Delete(int id)
        {
            var tacgia = tacgias.FirstOrDefault(u => u.MaTG == id);
            if (tacgia == null)
            {
                return HttpNotFound();
            }
            return View(tacgia);
        }

        // POST: TacGias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var tacgia = tacgias.FirstOrDefault(u => u.MaTG == id);
                if (tacgia != null)
                {
                    tacgias.Remove(tacgia);
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
