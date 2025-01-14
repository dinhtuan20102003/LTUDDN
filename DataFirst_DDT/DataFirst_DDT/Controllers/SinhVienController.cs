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
    public class SinhVienController : Controller
    {
        private QLSVDataContext db = new QLSVDataContext();

        // GET: SinhVien
        public ActionResult Index()
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop);
            return View(sinhViens.ToList());
        }
        public ActionResult Timkiem(string tk)
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop);
            if (!string.IsNullOrWhiteSpace(tk))
            {
                tk = tk.ToLower().Trim();
                sinhViens = sinhViens.Where(sv => sv.Lop.Tenlop.Trim().ToLower().Contains(tk));
            }
            return View(sinhViens.ToList());
        }
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhVien/Create
        public ActionResult Create()
        {
            ViewBag.Malop = new SelectList(db.Lops, "Malop", "Tenlop");
            return View();
        }

        // POST: SinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masv,Hoten,Ngaysinh,Gioitinh,Malop")] SinhVien sinhVien)
        {
            var check = db.SinhViens.FirstOrDefault(s => s.Masv == sinhVien.Masv);
            if (check != null)
            {
                ModelState.AddModelError("Masv", "Sinh viên đã tồn tại.");
            }
            if (ModelState.IsValid)
            {
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Malop = new SelectList(db.Lops, "Malop", "Tenlop", sinhVien.Malop);
            return View(sinhVien);
        }

        // GET: SinhVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Malop = new SelectList(db.Lops, "Malop", "Tenlop", sinhVien.Malop);
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masv,Hoten,Ngaysinh,Gioitinh,Malop")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Malop = new SelectList(db.Lops, "Malop", "Tenlop", sinhVien.Malop);
            return View(sinhVien);
        }

        // GET: SinhVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
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
