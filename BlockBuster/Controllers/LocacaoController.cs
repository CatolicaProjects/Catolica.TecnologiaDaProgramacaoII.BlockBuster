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
    public class LocacaoController : Controller
    {
        private Repository db = new Repository();

        public ActionResult Index()
        {
            return View(db.Locacoes.ToList());
        }

        public ActionResult Details(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Locacao locacao)
        {
            locacao.Copia = db.Copias.Find(locacao.CopiaId);
            locacao.Cliente = db.Clientes.Find(locacao.ClienteId);
            if (!locacao.PossuiCreditos())
            {
                ViewBag.Erro = "Cliente não possui créditos suficientes para locação";
                return View(locacao);
            }
            else
            {
                ViewBag.Erro = string.Empty;
            }

            if (ModelState.IsValid)
            {
                db.Locacoes.Add(locacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locacao);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
        public ActionResult SetDevolucao(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult SetDevolucao(Int64 id, DateTime dataDevolucao)
        {
            Locacao locacao = db.Locacoes.Find(id);
            locacao.DataDevolucao = dataDevolucao;
            if (ModelState.IsValid)
            {
                db.Entry(locacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locacao);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        [Authorize(Roles = "admin")]
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