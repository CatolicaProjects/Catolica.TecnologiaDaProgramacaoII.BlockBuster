using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BlockBuster.Controllers
{
    public class ChartController : Controller
    {
        private Repository db = new Repository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AtoresEOTotalDeTitulosPorAtor()
        {
            List<Object[]> data = new List<Object[]>();
            var atores = db.Atores.ToList();

            foreach (var ator in atores)
            {
                data.Add(new Object[] { ator.Nome, ator.Titulos.Count() });
            }

            return Json(data.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}



