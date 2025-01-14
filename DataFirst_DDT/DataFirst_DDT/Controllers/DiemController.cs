using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataFirst_DDT.Models;

namespace DataFirst_DDT.Controllers
{
    public class DiemController : Controller
    {
        private QLSVDataContext db = new QLSVDataContext();

        // GET: Diem
        public ActionResult Index()
        {
            var diems = db.Diems.Include(d => d.SinhVien);
            return View(diems.ToList());
        }
        public ActionResult Diemmax()
        {
            var diems = db.Diems.Include(d => d.SinhVien);
            diems = diems.OrderByDescending(d => d.Diemtb).Take(1);
            return View(diems.ToList());
        }
        public ActionResult Diemtb()
        {
            var diemtb = (double)db.SinhViens
                .Where(sv => sv.Lop.Tenlop == "DHTI15A1CL")
                .SelectMany(sv => sv.Diems)
                .Average(d => d.Diemtb);

            ViewBag.diemtb = Math.Round(diemtb, 2); 
            return View();
        }



        // GET: Diem/Details/5
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null|| id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id,id2);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diem/Create
        public ActionResult Create()
        {
            ViewBag.Masv = new SelectList(db.SinhViens, "Masv", "Hoten");
            return View();
        }

        // POST: Diem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masv,Mamh,Diemtb")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(diem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Masv = new SelectList(db.SinhViens, "Masv", "Hoten", diem.Masv);
            return View(diem);
        }

        // GET: Diem/Edit/5
        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null|| id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id, id2);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Masv = new SelectList(db.SinhViens, "Masv", "Hoten", diem.Masv);
            return View(diem);
        }

        // POST: Diem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masv,Mamh,Diemtb")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Masv = new SelectList(db.SinhViens, "Masv", "Hoten", diem.Masv);
            return View(diem);
        }

        // GET: Diem/Delete/5
        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id, id2);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            Diem diem = db.Diems.Find(id, id2);
            db.Diems.Remove(diem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
