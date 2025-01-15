using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTVN_Tuan6_DDT.Models;

namespace BTVN_Tuan6_DDT.Controllers
{
    public class BanhangsController : Controller
    {
        private QLBH db = new QLBH();

        // GET: Banhangs
        public ActionResult Index(string search)
        {
            var banhangs = db.Banhangs.Include(b => b.Nhanvien).Include(b => b.Sanpham);
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();
                banhangs = banhangs.Where(bh => bh.Sanpham.Tensp.Trim().ToLower().Contains(search));
            }
            return View(banhangs.ToList());
        }
        public ActionResult Sapxep()
        {
            var banhangs = db.Banhangs.Include(b => b.Nhanvien).Include(b => b.Sanpham);
            banhangs = banhangs.Where(bh => bh.Slban > bh.Dinhmuc).OrderBy(bh => bh.Slban > bh.Dinhmuc);
            return View(banhangs.ToList());
        }

        // GET: Banhangs/Details/5
        public ActionResult Details(int? id, string manv, string masp)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banhang banhang = db.Banhangs.Find(id, manv, masp);
            if (banhang == null)
            {
                return HttpNotFound();
            }
            return View(banhang);
        }

        // GET: Banhangs/Create
        public ActionResult Create()
        {
            ViewBag.Manv = new SelectList(db.Nhanviens, "Manv", "Tenquay");
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp");
            return View();
        }

        // POST: Banhangs/Create
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

        // GET: Banhangs/Edit/5
        public ActionResult Edit(int? id, string manv, string masp)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banhang banhang = db.Banhangs.Find(id, manv, masp);
            if (banhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Manv = new SelectList(db.Nhanviens, "Manv", "Tenquay", banhang.Manv);
            ViewBag.Masp = new SelectList(db.Sanphams, "Masp", "Tensp", banhang.Masp);
            return View(banhang);
        }

        // POST: Banhangs/Edit/5
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

        // GET: Banhangs/Delete/5
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

        // POST: Banhangs/Delete/5
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

        public ActionResult Tongsoluongbannhanvien()
        {
            var result = db.Banhangs.GroupBy(b => new { b.Nhanvien.Manv, b.Nhanvien.Hoten })
                .Select(g => new Class1
                {
                    Manv = g.Key.Manv,
                    Hoten = g.Key.Hoten,
                    Tongsl = g.Sum(b => b.Slban)
                }).ToList();
           
            return View(result);
        }
        public ActionResult SanPhamBanNhieuNhat()
        {
            var result = db.Banhangs .GroupBy(b => new {b.Sanpham.Masp, b.Sanpham.Tensp})
                .Select(g => new
                {
                    Masp = g.Key.Masp,
                    Tensp = g.Key.Tensp,
                    Tongsl = g.Sum(b =>b.Slban)
                }).OrderByDescending(b => b.Tongsl).FirstOrDefault(); 
            if(result != null)
            {
                ViewBag.Masp = result.Masp;
                ViewBag.Tensp = result.Tensp;
                ViewBag.Tongsl = result.Tongsl;

            }
            return View();
        }










    }
}
