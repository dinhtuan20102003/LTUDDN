using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TruyVanLinq_QLSach_LTUDDN.Models;

namespace TruyVanLinq_QLSach_LTUDDN.Controllers
{
    public class Book10Controller : Controller
    {
        private BookDataContext db = new BookDataContext();

        // GET: Book10
        public ActionResult Index(int? page, string sortOrder, string currentsearchString, string searchString, int currentCateggoryID = 0, int CategoryID = 0)
        {
           
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            //Lấy tất cả sách trong bảng book
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            //Lưu lại trạng thái sắp xếp, mọi trang như nhau
            ViewBag.currentSort = sortOrder;
            //Gán số trang cho biến page
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                page = 1;
            }
            else searchString = currentsearchString;

            if (CategoryID != 0)
            {
                page = 1;
            }
            else CategoryID = currentCateggoryID;
            //Truyền trạng thái tìm kíếm hiện tại sang view 
            ViewBag.currentsearchString = searchString;
            ViewBag.currentCateggoryID = CategoryID;
            //Tìm kiếm theo tiêu đề sách
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim().ToLower();
                books = books.Where(b => b.Title.Trim().ToLower().Contains(searchString));
            }
            //Tìm kiếm theo chủ đề
            if (CategoryID != 0)
            {
                books = books.Where(b => b.CategoryID == CategoryID);
            }
            //Hoán vị trạng thái sắp xếp
            if (string.IsNullOrEmpty(sortOrder))
                ViewBag.TitleSort = "title_desc";
            else
                ViewBag.TitleSort = "";
            if (sortOrder == "price_asc")
                ViewBag.PriceSort = "price_desc";
            else
                ViewBag.PriceSort = "price_asc";
            //Sắp xếp
            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "price_desc":
                    books = books.OrderByDescending(b => b.Price);
                    break;
                case "price_asc":
                    books = books.OrderBy(b => b.Price);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;


            }
            int pageSize = 2;
            int pageNumber = (page ?? 1);

            return View(books.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index1(string sortOrder, string searchString, int CategoryID = 0)
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");

            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            //Tìm kiếm theo tiêu đề sách
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim().ToLower();
                books = books.Where(b => b.Title.Trim().ToLower().Contains(searchString));
            }
            //Tìm kiếm theo chủ đề
            if (CategoryID != 0)
            {
                books = books.Where(b => b.CategoryID == CategoryID);
            }
            //Hoán vị trạng thái sắp xếp
            if (string.IsNullOrEmpty(sortOrder))
                ViewBag.TitleSort = "title_desc";
            else
                ViewBag.TitleSort = "";
            if (sortOrder == "price_asc")
                ViewBag.PriceSort = "price_desc";
            else
                ViewBag.PriceSort = "price_asc";
            //Sắp xếp
            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "price_desc":
                    books = books.OrderByDescending(b => b.Price);
                    break;
                case "price_asc":
                    books = books.OrderBy(b => b.Price);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;


            }
            return View(books.ToList());
        }

        // GET: Book10/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book10/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Book10/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,AuthorID,Price,Images,CategoryID,Description,Published,ViewCount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Book10/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // POST: Book10/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,AuthorID,Price,Images,CategoryID,Description,Published,ViewCount")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", book.CategoryID);
            return View(book);
        }

        // GET: Book10/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book10/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
