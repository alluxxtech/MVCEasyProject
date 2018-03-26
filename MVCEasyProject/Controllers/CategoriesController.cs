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
    public class CategoriesController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();

        // GET: Categories
        public ActionResult Index()
        {
            var model = db.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return View(model);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            var category = db.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            DetailsCategoryViewModel model = new DetailsCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
            
            return View(model);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryViewModel model)
        {          
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name
                };
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Categories/Edit
        public ActionResult Edit(int id)
        {
            var category = db.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
            {
                return HttpNotFound(); //вернет статус код 404 
            }
            EditCategoryViewModel model = new EditCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(model);
        }

        // POST: Categories/Edit
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = db.Categories.SingleOrDefault(c => c.Id == model.Id);
                category.Name = model.Name;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //GET Delete 
        //public ActionResult Delete(int id)
        //{
        //    var category = db.Categories.SingleOrDefault(c => c.Id == id);
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    DeleteCategoryViewModel model = new DeleteCategoryViewModel
        //    {
        //        Id = category.Id
        //    };
        //    return View(model);
        //}

        // POST: Categories/Delete
        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            //List<Product> products = db.Categories.SingleOrDefault(c => c.Id == id).Products.ToList();
            //if (products.Count > 0)
            //{
            //    foreach (var a in products)
            //    {

            //    }
            //}
            Category category = db.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return Content("Deleted Successfully!");
            }
              
            return Content("error delete db");
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
