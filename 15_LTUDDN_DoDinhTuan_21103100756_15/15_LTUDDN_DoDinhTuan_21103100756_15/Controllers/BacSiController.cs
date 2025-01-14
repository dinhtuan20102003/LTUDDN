﻿using System;
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
    public class BacSiController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: BacSi
        public ActionResult Index()
        {
            return View(db.BacSis.ToList());
        }

        // GET: BacSi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // GET: BacSi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BacSi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBS,TenBS,ChuyenKhoa,SoNamKinhNghiem,DienThoai")] BacSi bacSi)
        {
            if (ModelState.IsValid)
            {
                db.BacSis.Add(bacSi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bacSi);
        }

        // GET: BacSi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // POST: BacSi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBS,TenBS,ChuyenKhoa,SoNamKinhNghiem,DienThoai")] BacSi bacSi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bacSi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bacSi);
        }

        // GET: BacSi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // POST: BacSi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BacSi bacSi = db.BacSis.Find(id);
            db.BacSis.Remove(bacSi);
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
