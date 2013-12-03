using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockBuster.Models;

namespace BlockBuster.Controllers
{
    [Authorize]
    public class AtorController : Controller
    {
        private Repository db = new Repository();

        public ActionResult Index()
        {
            return View(db.Atores.ToList());
        }

        public ActionResult Details(long id = 0)
        {
            Ator ator = db.Atores.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Ator ator)
        {
            if (ModelState.IsValid)
            {
                db.Atores.Add(ator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ator);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(long id = 0)
        {
            Ator ator = db.Atores.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Ator ator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ator);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(long id = 0)
        {
            Ator ator = db.Atores.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Ator ator = db.Atores.Find(id);
            db.Atores.Remove(ator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}