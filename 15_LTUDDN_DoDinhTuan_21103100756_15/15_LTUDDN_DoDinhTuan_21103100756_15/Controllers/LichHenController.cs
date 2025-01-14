using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _15_LTUDDN_DoDinhTuan_21103100756_15.Models;

namespace _15_LTUDDN_DoDinhTuan_21103100756_15.Controllers
{
    public class LichHenController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: LichHen
        public ActionResult Index()
        {
            var lichHens = db.LichHens.Include(l => l.BacSi).Include(l => l.BenhNhan);
            return View(lichHens.ToList());
        }

        public ActionResult Sonamkinhnghiemnhieunhat()
        {
            var lichHens = db.LichHens.Include(l => l.BacSi).Include(l => l.BenhNhan);
            var max = db.BacSis.Max(d => d.SoNamKinhNghiem);
            var dsbs = db.BacSis.Where(d => d.SoNamKinhNghiem == max);
            return View(dsbs.ToList());
        }

        public ActionResult Tongdoanhthutienkham()
        {
            var lichHens = db.LichHens.Include(l => l.BacSi).Include(l => l.BenhNhan);
            var bacsi = db.LichHens.GroupBy(l => new { l.BacSi.MaBS, l.BacSi.TenBS, l.BacSi.ChuyenKhoa, l.BacSi.SoNamKinhNghiem, l.BacSi.DienThoai })
                .Select(d => new Tongdoanhthu
                {
                    MaBS = d.Key.MaBS,
                    TenBS = d.Key.TenBS,
                    ChuyenKhoa = d.Key.ChuyenKhoa,
                    SoNamKinhNghiem = d.Key.SoNamKinhNghiem,
                    DienThoai = d.Key.DienThoai,
                    TongDoanhThu = d.Key.SoNamKinhNghiem >= 10
                ? d.Count() * 500000
                : d.Count() * 300000
                });
            return View(bacsi.ToList());
        }

        public ActionResult TimKiem(string timkiem1, string timkiem2)
        {
            var lichHens = db.LichHens.Include(l => l.BacSi).Include(l => l.BenhNhan);
            ViewBag.TenBS = new SelectList(db.BacSis.Select(b => b.TenBS).Distinct().ToList(), "TenBS");
            if (!string.IsNullOrWhiteSpace(timkiem1))
            {
                timkiem1 = timkiem1.Trim().ToLower();
                lichHens = lichHens.Where(l => l.BenhNhan.HoTenBN.ToLower().Trim().Contains(timkiem1));
            }
            if (!string.IsNullOrWhiteSpace(timkiem2))
            {
                timkiem2 = timkiem2.Trim().ToLower();
                lichHens = lichHens.Where(l => l.BacSi.TenBS.ToLower().Trim().Contains(timkiem2));
            }
            return View(lichHens.ToList());
        }

        // GET: LichHen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHens.Find(id);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            return View(lichHen);
        }

        // GET: LichHen/Create
        public ActionResult Create()
        {
            ViewBag.MaBS = new SelectList(db.BacSis, "MaBS", "TenBS");
            ViewBag.MaBN = new SelectList(db.BenhNhans, "MaBN", "HoTenBN");
            return View();
        }

        // POST: LichHen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLichHen,MaBN,MaBS,NgayHen,LyDo")] LichHen lichHen)
        {
            if (ModelState.IsValid)
            {
                db.LichHens.Add(lichHen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBS = new SelectList(db.BacSis, "MaBS", "TenBS", lichHen.MaBS);
            ViewBag.MaBN = new SelectList(db.BenhNhans, "MaBN", "HoTenBN", lichHen.MaBN);
            return View(lichHen);
        }

        // GET: LichHen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHens.Find(id);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBS = new SelectList(db.BacSis, "MaBS", "TenBS", lichHen.MaBS);
            ViewBag.MaBN = new SelectList(db.BenhNhans, "MaBN", "HoTenBN", lichHen.MaBN);
            return View(lichHen);
        }

        // POST: LichHen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLichHen,MaBN,MaBS,NgayHen,LyDo")] LichHen lichHen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichHen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBS = new SelectList(db.BacSis, "MaBS", "TenBS", lichHen.MaBS);
            ViewBag.MaBN = new SelectList(db.BenhNhans, "MaBN", "HoTenBN", lichHen.MaBN);
            return View(lichHen);
        }

        // GET: LichHen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichHen lichHen = db.LichHens.Find(id);
            if (lichHen == null)
            {
                return HttpNotFound();
            }
            return View(lichHen);
        }

        // POST: LichHen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichHen lichHen = db.LichHens.Find(id);
            db.LichHens.Remove(lichHen);
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
