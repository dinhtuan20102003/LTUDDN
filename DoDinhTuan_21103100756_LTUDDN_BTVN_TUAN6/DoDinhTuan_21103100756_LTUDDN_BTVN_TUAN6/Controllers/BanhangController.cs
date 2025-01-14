using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.Models;

namespace DoDinhTuan_21103100756_LTUDDN_BTVN_TUAN6.Controllers
{
    public class BanhangController : Controller
    {
        private QLBH db = new QLBH();

        // GET: Banhang
        public ActionResult Index(string timkiem)
        {
            var banhangs = db.Banhangs.Include(b => b.Nhanvien).Include(b => b.Sanpham);
            if (!string.IsNullOrWhiteSpace(timkiem))
            {
                timkiem = timkiem.ToLower().Trim();
                banhangs = banhangs.Where(bh => bh.Sanpham.Tensp.Trim().ToLower().Contains(timkiem));
            }
            return View(banhangs.ToList());
        }
        public ActionResult TongSlban()
        {
           var tong = db.Banhangs.GroupBy(bh => new {bh.Nhanvien.Manv, bh.Nhanvien.Hoten})
                .Select(g => new Tong
                {
                    Manv = g.Key.Manv,
                    Hoten = g.Key.Hoten,
                    Tongsl = g.Sum(bh => bh.Slban)
                }).ToList();
            return View(tong);
        }
        public ActionResult TongSlban1()
        {
            var tong = db.Banhangs.Sum(bh => bh.Slban); // Tổng tất cả số lượng bán
            ViewBag.TongSl = tong;
            return View();
        }
        public ActionResult Banhangvdm()
        {
            var banhangs = db.Banhangs.Include(b => b.Nhanvien).Include(b => b.Sanpham);
            banhangs = banhangs.Where(bh => bh.Slban > bh.Dinhmuc).OrderByDescending(bh => bh.Slban);
            return View(banhangs.ToList());
        }

        public ActionResult Sanphambannhieunhat()
        {
            var sanpham = db.Banhangs.GroupBy(bh => new { bh.Sanpham.Masp, bh.Sanpham.Tensp })
                .Select(g => new
                {
                    Masp = g.Key.Masp,
                    Tensp = g.Key.Tensp,
                    Tongsl = g.Sum(bh => bh.Slban)
                }).OrderByDescending(bh => bh.Tongsl).FirstOrDefault();
            if(sanpham != null)
            {
                ViewBag.Masp = sanpham.Masp;
                ViewBag.Tensp = sanpham.Tensp;
                ViewBag.Tongsl = sanpham.Tongsl;
            }
            return View();
        }
        // GET: Banhang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banhang banhang = db.Banhangs.Find(id);
            if (banhang == null)
            {
                return HttpNotFound();
            }
            return View(banhang);
        }

        // GET: Banhang/Create
        public ActionResult Create()
        {
            ViewBag.Manv = new SelectList(db.Nhanviens, "Manv", "Tenquay");
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp");
            return View();
        }

        // POST: Banhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Manv,Masp,Dinhmuc,Slban")] Banhang banhang)
        {
            if (ModelState.IsValid)
            {
                db.Banhangs.Add(banhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manv = new SelectList(db.Nhanviens, "Manv", "Tenquay", banhang.Manv);
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp", banhang.Masp);
            return View(banhang);
        }

        // GET: Banhang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banhang banhang = db.Banhangs.Find(id);
            if (banhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Manv = new SelectList(db.Nhanviens, "Manv", "Tenquay", banhang.Manv);
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp", banhang.Masp);
            return View(banhang);
        }

        // POST: Banhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Manv,Masp,Dinhmuc,Slban")] Banhang banhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Manv = new SelectList(db.Nhanviens, "Manv", "Tenquay", banhang.Manv);
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp", banhang.Masp);
            return View(banhang);
        }

        // GET: Banhang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banhang banhang = db.Banhangs.Find(id);
            if (banhang == null)
            {
                return HttpNotFound();
            }
            return View(banhang);
        }

        // POST: Banhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banhang banhang = db.Banhangs.Find(id);
            db.Banhangs.Remove(banhang);
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
