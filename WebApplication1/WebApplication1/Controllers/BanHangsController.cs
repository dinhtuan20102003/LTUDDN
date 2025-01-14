using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BanHangsController : Controller
    {
        private QLBHDataContext db = new QLBHDataContext();

        // GET: BanHangs
        public ActionResult Index()
        {
            var banHangs = db.BanHangs.Include(b => b.NhanVien).Include(b => b.SanPham);
            return View(banHangs.ToList());
        }

        public ActionResult Tong()
        {
           var tong = db.BanHangs.GroupBy(bh =>new {bh.NhanVien.manv, bh.NhanVien.hoten})
                .Select(g => new Tong
                {
                    manv = g.Key.manv,
                    Hoten = g.Key.hoten,
                    tongsl = g.Sum(bh => bh.slban)
                }
                    
                ).ToList();
            return View(tong);
        }


        // GET: BanHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanHang banHang = db.BanHangs.Find(id);
            if (banHang == null)
            {
                return HttpNotFound();
            }
            return View(banHang);
        }

        // GET: BanHangs/Create
        public ActionResult Create()
        {
            ViewBag.manv = new SelectList(db.NhanViens, "manv", "tenquay");
            ViewBag.masp = new SelectList(db.SanPhams, "masp", "tensp");
            return View();
        }

        // POST: BanHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "manv,masp,dinhmuc,slban")] BanHang banHang)
        {
            if (ModelState.IsValid)
            {
                db.BanHangs.Add(banHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.manv = new SelectList(db.NhanViens, "manv", "tenquay", banHang.manv);
            ViewBag.masp = new SelectList(db.SanPhams, "masp", "tensp", banHang.masp);
            return View(banHang);
        }

        // GET: BanHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanHang banHang = db.BanHangs.Find(id);
            if (banHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.manv = new SelectList(db.NhanViens, "manv", "tenquay", banHang.manv);
            ViewBag.masp = new SelectList(db.SanPhams, "masp", "tensp", banHang.masp);
            return View(banHang);
        }

        // POST: BanHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "manv,masp,dinhmuc,slban")] BanHang banHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.manv = new SelectList(db.NhanViens, "manv", "tenquay", banHang.manv);
            ViewBag.masp = new SelectList(db.SanPhams, "masp", "tensp", banHang.masp);
            return View(banHang);
        }

        // GET: BanHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanHang banHang = db.BanHangs.Find(id);
            if (banHang == null)
            {
                return HttpNotFound();
            }
            return View(banHang);
        }

        // POST: BanHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BanHang banHang = db.BanHangs.Find(id);
            db.BanHangs.Remove(banHang);
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
