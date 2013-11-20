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

        public JsonResult GenerosEOTotalDeTitulosPorGenero()
        {
            List<Object[]> data = new List<Object[]>();
            var generos = db.Generos.ToList();

            foreach (var genero in generos)
            {
                data.Add(new Object[] { genero.Descricao, genero.Titulos.Count() });
            }

            return Json(data.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClientesEOTotalDeTitulosLocados()
        {
            List<Object[]> data = new List<Object[]>();
            var clientes = db.Clientes.ToList();

            foreach (var cliente in clientes)
            {
                data.Add(new Object[] { cliente.Nome, cliente.Locacoes.Count() });
            }

            return Json(data.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Top10DosTitulosMaisLocadosPorPeriodo(string dataInicial, string dataFinal)
        {
            List<Object[]> data = new List<Object[]>();

            DateTime dIni = Convert.ToDateTime(dataInicial);
            DateTime dFim = Convert.ToDateTime(dataFinal);

            var copias = db.Copias.ToList();
            var titulos = db.Titulos.ToList();
            //var locacoes = db.Locacoes.ToList();

            /*
            var titulosEntreAsDatas = (from t in titulos
                                       join c in copias on t.Id equals c.TituloId
                                       join l in locacoes on c.Id equals l.CopiaId
                                       where l.DataLocacao >= dIni && l.DataLocacao <= dFim
                                       select t);
            */

            IDictionary<Titulo, int> assistente = new Dictionary<Titulo, int>();

            foreach (var titulo in titulos)
            {
                foreach (var copia in titulo.Copias)
                {
                    var locacoesNessePeriodo = copia.Locacoes.Where(w => w.DataLocacao >= dIni && w.DataLocacao <= dFim);
                    bool algumaLocacaoNessePeriodo = locacoesNessePeriodo.Any();
                    if (algumaLocacaoNessePeriodo)
                    {
                        if (assistente.ContainsKey(titulo))
                        {
                            assistente[titulo] += locacoesNessePeriodo.Count();
                        }
                        else
                        {
                            assistente.Add(titulo, locacoesNessePeriodo.Count());
                        }
                    }
                }
            }

            var top10 = (from a in assistente
                         orderby a.Value descending
                         select a).Take(10);

            foreach (var item in top10)
            {
                data.Add(new Object[] { item.Key.Nome, item.Value });
            }

            return Json(data.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}



