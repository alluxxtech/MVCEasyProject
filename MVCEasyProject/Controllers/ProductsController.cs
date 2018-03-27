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
            CreateProductViewModel model = new CreateProductViewModel
            {
                Price = 0
            };
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
           
            return View(model);
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
        public ActionResult Edit(int id)
        {
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            EditProductViewModel model = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Company = product.Company,
                Description = product.Description,
                Price = (int)product.Price,
                InStock = product.InStock,
                CategoryId = product.CategoryId
            };
                        
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", model.CategoryId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    Company = model.Company,
                    Description = model.Description,
                    Price = model.Price,
                    InStock = model.InStock,
                    CategoryId = model.CategoryId,
                    Category = db.Categories.SingleOrDefault(c => c.Id == model.CategoryId)                   
                }; 
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", model.CategoryId);
            return View(model);
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
