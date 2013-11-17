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
            var titulos = db.Titulos.Include(i => i.Atores).ToList();
            return View(titulos);
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
            ViewBag.MultiSelectAtores = new MultiSelectList(db.Atores.ToList(), "Id", "Nome");
            return View();
        }

        //
        // POST: /Titulo/Create

        [HttpPost]
        public ActionResult Create(Titulo titulo, FormCollection formCollection, string[] arrayAtores)
        {
            if (arrayAtores != null)
            {
                titulo.Atores = new List<Ator>();
                foreach (var ator in arrayAtores)
                {
                    var atorToAdd = db.Atores.Find(int.Parse(ator));
                    titulo.Atores.Add(atorToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                db.Titulos.Add(titulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MultiSelectAtores = new MultiSelectList(db.Atores.ToList(), "Id", "Nome");
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
            ViewBag.MultiSelectAtores = new MultiSelectList(db.Atores.ToList(), "Id", "Nome");
            return View(titulo);
        }

        //
        // POST: /Titulo/Edit/5

        [HttpPost]
        public ActionResult Edit(int? id, FormCollection formCollection, string[] arrayAtores)
        {
            var tituloToUpdate = db.Titulos
                .Include(i => i.Atores)
                .Where(i => i.Id == id)
                .Single();

            if (arrayAtores == null)
            {
                tituloToUpdate.Atores = new List<Ator>();
            }

            var selectedAtoresHS = new HashSet<string>(arrayAtores);

            var tituloAtores = new HashSet<Int64>(tituloToUpdate.Atores.Select(s => s.Id));

            foreach (var ator in db.Atores)
            {
                if (selectedAtoresHS.Contains(ator.Id.ToString()))
                {
                    if (!tituloAtores.Contains(ator.Id))
                    {
                        tituloToUpdate.Atores.Add(ator);
                    }
                }
                else
                {
                    if (tituloAtores.Contains(ator.Id))
                    {
                        tituloToUpdate.Atores.Remove(ator);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(tituloToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MultiSelectAtores = new MultiSelectList(db.Atores.ToList(), "Id", "Nome");
            return View(tituloToUpdate);
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