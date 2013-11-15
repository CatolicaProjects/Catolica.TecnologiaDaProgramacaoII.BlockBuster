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
    //TODO: descomentar [Authorize]
    public class TituloController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Titulo/

        public ActionResult Index()
        {
            return View(db.Titulos.ToList());
        }

        //
        // GET: /Titulo/Details/5

        public ActionResult Details(long id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        //
        // GET: /Titulo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Titulo/Create

        [HttpPost]
        public ActionResult Create(Titulo titulo)
        {
            if (ModelState.IsValid)
            {
                db.Titulos.Add(titulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(titulo);
        }

        //
        // GET: /Titulo/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        //
        // POST: /Titulo/Edit/5

        [HttpPost]
        public ActionResult Edit(Titulo titulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(titulo);
        }

        //
        // GET: /Titulo/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        //
        // POST: /Titulo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Titulo titulo = db.Titulos.Find(id);
            db.Titulos.Remove(titulo);
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