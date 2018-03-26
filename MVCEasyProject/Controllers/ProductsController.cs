using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEasyProject.Models;

namespace MVCEasyProject.Controllers
{
    public class ProductsController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();

        // GET: Products
        public ActionResult Index()
        {
            var model = db.Products
                .Include(c => c.Category)
                .Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Company = p.Company,
                Description = p.Description,
                InStock = p.InStock,
                Price = p.Price,
                CategoryName = p.Category.Name
            }).ToList();
            return View(model);
           
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            var product = db.Products.Include(c => c.Category).SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            DetailsProductViewModel model = new DetailsProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Company = product.Company,
                Price = product.Price,
                InStock = product.InStock,
                CategoryName = product.Category.Name
            };
            return View(model);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Company = model.Company,
                    Description = model.Description,
                    Price = model.Price,
                    InStock = model.InStock,
                    CategoryId = model.CategoryId,
                    Category = db.Categories.SingleOrDefault(c => c.Id == model.CategoryId)                    
                };
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", model.CategoryId);
            return View(model);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Company,Description,Price,InStock,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
