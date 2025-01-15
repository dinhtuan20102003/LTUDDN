using DDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDT.Controllers
{
    public class DatSachsController : Controller
    {
        // GET: DatSachs
        public static List<DatSach> datsachs = new List<DatSach>
        {
            new DatSach{MaSach = 1, MaTG = 1, TenSach = "Anh Yeu Em", Gia = 300000, SoLuong= 10},
             new DatSach{MaSach = 2, MaTG = 2, TenSach = "Anh Yeu Em", Gia = 300000, SoLuong= 10}
        };
        public ActionResult Index()
        {

            return View(datsachs);
        }

        // GET: DatSachs/Details/5
        public ActionResult Details(int id)
        {
            var datsach = datsachs.FirstOrDefault(u => u.MaSach == id);
            if (datsach == null)
            {
                HttpNotFound();
            }
            return View(datsach);
        }

        // GET: DatSachs/Create
        public ActionResult Create()
        {
            ViewBag.TacGias = new SelectList(TacGiasController.tacgias, "MaTG", "HoTen");
            return View();
        }

        // POST: DatSachs/Create
        [HttpPost]
        public ActionResult Create(DatSach newDatSach)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newDatSach.MaSach = datsachs.Max(u => u.MaSach) + 1;
                    datsachs.Add(newDatSach);
                    return RedirectToAction("Index");
                }
                ViewBag.TacGias = new SelectList(TacGiasController.tacgias, "MaTG", "HoTen");
                return View(newDatSach);
            }
            catch
            {
                return View();
            }
        }

        // GET: DatSachs/Edit/5
        public ActionResult Edit(int id)
        {
            var datsach = datsachs.FirstOrDefault(u => u.MaSach == id);
            if (datsach == null) { HttpNotFound(); }
            return View(datsach);
        }

        // POST: DatSachs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DatSach updateDatSach)
        {
            try
            {
                // TODO: Add update logic here
                var datsach = datsachs.FirstOrDefault(u => u.MaSach == id);
                if (datsach == null)
                {

                    HttpNotFound();
                }
                else if (ModelState.IsValid)
                {
                    datsach.MaTG = updateDatSach.MaTG;
                    datsach.TenSach = updateDatSach.TenSach;
                    datsach.Gia = updateDatSach.Gia;
                    datsach.SoLuong = updateDatSach.SoLuong;
                    return RedirectToAction("Index");
                }

                return View(updateDatSach);
            }

            catch
            {
                return View();
            }
        }

        // GET: DatSachs/Delete/5
        public ActionResult Delete(int id)
        {
            var datsach = datsachs.FirstOrDefault(u => u.MaSach == id);
            if (datsach == null) { HttpNotFound(); }
            return View(datsach);
            return View();
        }

        // POST: DatSachs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var datsach = datsachs.FirstOrDefault(u => u.MaSach == id);
                if (datsach != null)
                {
                    datsachs.Remove(datsach);
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
