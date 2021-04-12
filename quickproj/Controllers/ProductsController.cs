using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using quickproj.Models;

namespace quickproj.Controllers
{
    public class ProductsController : Controller
    {
        private quickprojectEntities db = new quickprojectEntities();

        public ActionResult Index()
        {
            var dbmodel = db.Products.ToList();
            return View(dbmodel);
        }

        public ActionResult Details(int? id)
        {
           
            Product product = db.Products.Find(id);
            
            return View(product);
        }

        public ActionResult Create()
        {
            Product productmodel = new Product();
            productmodel.ProductKategories = db.Kategories.ToList();
            return View(productmodel);
        }

        
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            
            Product product = db.Products.Find(id);
            
            return View(product);
        }

        
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            
            Product product = db.Products.Find(id);
           
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
