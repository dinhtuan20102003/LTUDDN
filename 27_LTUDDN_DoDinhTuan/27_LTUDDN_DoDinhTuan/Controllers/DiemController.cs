using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _27_LTUDDN_DoDinhTuan.Models;

namespace _27_LTUDDN_DoDinhTuan.Controllers
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

        public ActionResult Max()
        {
            var diems = db.Diems.Include(d => d.SinhVien);

            var diemCao = diems.Where(d => d.tenmh == "Cơ sở dữ liệu").Min(d=>d.diem);
            var diem = diems.Where(d => d.tenmh == "Cơ sở dữ liệu" && d.diem == diemCao);
            return View(diem.ToList());
        }

        public ActionResult TK(string search)
        {
            var diems = db.Diems.Include(d => d.SinhVien);
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                diems = diems.Where(d => d.SinhVien.hoten.Trim().ToLower().Contains(search));
            }
            return View(diems.ToList());
        }

        // GET: Diem/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diem/Create
        public ActionResult Create()
        {
            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten");
            return View();
        }

        // POST: Diem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tenmh,masv,diem")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(diem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten", diem.masv);
            return View(diem);
        }

        // GET: Diem/Edit/5
        public ActionResult Edit(string id, int? id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id, id1);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten", diem.masv);
            return View(diem);
        }

        // POST: Diem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tenmh,masv,diem")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten", diem.masv);
            return View(diem);
        }

        // GET: Diem/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Diem diem = db.Diems.Find(id);
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
