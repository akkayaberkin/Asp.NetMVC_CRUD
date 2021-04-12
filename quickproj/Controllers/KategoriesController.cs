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
    public class KategoriesController : Controller
    {
        private quickprojectEntities db = new quickprojectEntities();

        public ActionResult Index()
        {
            return View(db.Kategories.ToList());
        }
        [HttpPost]
        public ActionResult Index(string search)
        {

            var list = db.Kategories.ToList();
            list = list.Where(x => x.KategoryName.Contains(search)).ToList();
            
            return View(list);
        }
        public ActionResult Details(int? id)
        {
           
            Kategory kategory = db.Kategories.Find(id);
            
            return View(kategory);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Kategory kategory)
        {
            if (ModelState.IsValid)
            {
                db.Kategories.Add(kategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategory);
        }
       

        public ActionResult Edit(int? id)
        {
           
            Kategory kategory = db.Kategories.Find(id);
            
            return View(kategory);
        }

        [HttpPost]
        public ActionResult Edit(Kategory kategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategory);
        }

        public ActionResult Delete(int? id)
        {
           
            Kategory kategory = db.Kategories.Find(id);
            
            return View(kategory);
        }

        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            Kategory kategory = db.Kategories.Find(id);
            db.Kategories.Remove(kategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
