using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _27_DoDinhTuan_21103100756_DHTI15A1CL.Models;

namespace _27_DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class DiemsController : Controller
    {
        private QLDIEMSVEntities db = new QLDIEMSVEntities();

        // GET: Diems
        public ActionResult Index(string search)
        {
            var diems = db.Diems.Include(d => d.SinhVien);
            if (!string.IsNullOrWhiteSpace(search)){
                search = search.Trim().ToLower();
                diems = diems.Where(d => d.SinhVien.hoten.Trim().ToLower().Contains(search));
            }
            return View(diems.ToList());
        }

        // GET: Diems/Details
        public ActionResult Details(int? masv, string tenmh)
        {
            if (masv == null || tenmh == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(masv, tenmh);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diems/Create
        public ActionResult Create()
        {
            ViewBag.masv = new SelectList(db.SinhViens, "masv", "masv");
            return View();
        }

        // POST: Diems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "masv,tenmh,diem1")] Diem diem)
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

        // GET: Diems/Edit
        public ActionResult Edit(int? masv, string tenmh)
        {
            if (masv == null || tenmh == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(masv, tenmh);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten", diem.masv);
            return View(diem);
        }

        // POST: Diems/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "masv,tenmh,diem1")] Diem diem)
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

        // GET: Diems/Delete
        public ActionResult Delete(int? masv, string tenmh)
        {
            if (masv == null || tenmh == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(masv, tenmh);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diems/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int masv, string tenmh)
        {
            Diem diem = db.Diems.Find(masv, tenmh);
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
        public ActionResult Diem()
        {

            var diemThapNhat = db.Diems.Where(d => d.tenmh == "Kỹ thuật lập trình").OrderBy(d => d.diem1).FirstOrDefault();

            if (diemThapNhat == null)
            {
                return HttpNotFound("Không tìm thấy sinh viên có điểm môn Kĩ thuật lập trình.");
            }


            return RedirectToAction("Details", new { masv = diemThapNhat.masv, tenmh = diemThapNhat.tenmh });

        }



    }
}
