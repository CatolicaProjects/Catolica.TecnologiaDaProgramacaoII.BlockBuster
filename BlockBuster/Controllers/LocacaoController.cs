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
    public class LocacaoController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Locacao/

        public ActionResult Index()
        {
            return View(db.Locacoes.ToList());
        }

        //
        // GET: /Locacao/Details/5

        public ActionResult Details(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        //
        // GET: /Locacao/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Locacao/Create

        [HttpPost]
        public ActionResult Create(Locacao locacao)
        {
            locacao.Copia = db.Copias.Find(locacao.CopiaId);
            locacao.Cliente = db.Clientes.Find(locacao.ClienteId);
            if (ModelState.IsValid)
            {
                db.Locacoes.Add(locacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locacao);
        }

        //
        // GET: /Locacao/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        //
        // POST: /Locacao/Edit/5

        [HttpPost]
        public ActionResult Edit(Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locacao);
        }

        //
        // GET: /Locacao/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        //
        // POST: /Locacao/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Locacao locacao = db.Locacoes.Find(id);
            db.Locacoes.Remove(locacao);
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