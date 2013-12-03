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
    public class CopiaController : Controller
    {
        private Repository db = new Repository();

        public ActionResult Index()
        {
            return View(db.Copias.ToList());
        }

        public ActionResult Details(long id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Copia copia)
        {
            copia.TipoCopia = db.TipoCopias.Find(copia.TipoCopiaId);
            copia.Titulo = db.Titulos.Find(copia.TituloId);
            if (ModelState.IsValid)
            {
                db.Copias.Add(copia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(copia);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(long id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Copia copia)
        {
            copia.TipoCopia = db.TipoCopias.Find(copia.TipoCopiaId);
            copia.Titulo = db.Titulos.Find(copia.TituloId);
            if (ModelState.IsValid)
            {
                db.Entry(copia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(copia);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(long id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Copia copia = db.Copias.Find(id);
            db.Copias.Remove(copia);
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