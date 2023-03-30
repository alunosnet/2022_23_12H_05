using Projeto_M17_Final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_M17_Final.Controllers
{
    public class ConsultasController : Controller
    {
        private Projeto_M17_FinalContext db = new Projeto_M17_FinalContext();

        // GET: Consultas
        public ActionResult Pesquisa()
        {
            return View("Index");
        }
        [HttpPost]
        [ActionName("Pesquisa")]
        public ActionResult PesquisaDinamica()
        {
            string nome = Request.Form["tbNome"];
            var clientes = db.Motoristas.Where(c => c.Nome.Contains(nome));
            return View("PesquisaMotorista",clientes.ToList());
        }
        
        public ActionResult MelhorMotorista()
        {
            string sql = @"SELECT nome,sum(valor_pago) as valor_pago
                            FROM Cargas INNER JOIN Motoristas
                            ON Cargas.MotoristaID=Motoristas.MotoristaID
                            GROUP BY Cargas.MotoristaID,nome
                            ORDER BY valor_pago DESC";

            var melhor = db.Database.SqlQuery<Campos>(sql);
            if (melhor != null && melhor.ToList().Count > 0)
                ViewBag.melhor = melhor.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.melhor = temp;
            }
            return View();
        }
        public ActionResult CargasMotorista()
        {

            return View();
        }
        [HttpPost]
        [ActionName("CargasMotorista")]
        public ActionResult CargasMotorista(string nome)
        {
            string sql = @"Select nome,count(*) as carga
                            from Cargas INNER JOIN Motoristas
                            ON Cargas.MotoristaID=Motoristas.MotoristaID
                            where nome like @p0
                            GROUP By nome";

            // SqlParameter parametro = new SqlParameter("@p1", "%" + nome + "%");
            var carga = db.Database.SqlQuery<Campos>(sql, "%" + nome + "%");

            if (carga != null && carga.ToList().Count > 0)
            {

                ViewBag.cargas = carga.ToList()[0];
            }
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.estadias = temp;
            }
            return View();
        }
        public class Campos
        {
            public string nome { get; set; }
            public decimal valor_pago { get; set; }
            public int carga{ get; set; }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}