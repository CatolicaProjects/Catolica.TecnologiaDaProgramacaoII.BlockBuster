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
    public class TipoTituloController : Controller
    {
        private Repository db = new Repository();

        public ActionResult Index()
        {
            return View(db.TipoTitulos.ToList());
        }

        public ActionResult Details(long id = 0)
        {
            TipoTitulo tipotitulo = db.TipoTitulos.Find(id);
            if (tipotitulo == null)
            {
                return HttpNotFound();
            }
            return View(tipotitulo);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(TipoTitulo tipotitulo)
        {
            if (ModelState.IsValid)
            {
                db.TipoTitulos.Add(tipotitulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipotitulo);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(long id = 0)
        {
            TipoTitulo tipotitulo = db.TipoTitulos.Find(id);
            if (tipotitulo == null)
            {
                return HttpNotFound();
            }
            return View(tipotitulo);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(TipoTitulo tipotitulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipotitulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipotitulo);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(long id = 0)
        {
            TipoTitulo tipotitulo = db.TipoTitulos.Find(id);
            if (tipotitulo == null)
            {
                return HttpNotFound();
            }
            return View(tipotitulo);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            TipoTitulo tipotitulo = db.TipoTitulos.Find(id);
            db.TipoTitulos.Remove(tipotitulo);
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