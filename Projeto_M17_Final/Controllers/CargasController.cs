using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_M17_Final.Data;
using Projeto_M17_Final.Models;

namespace Projeto_M17_Final.Controllers
{
    [Authorize]
    public class CargasController : Controller
    {
        private Projeto_M17_FinalContext db = new Projeto_M17_FinalContext();

        // GET: Cargas
        public ActionResult Index()
        {
            var cargas = db.Cargas.Include(c => c.camiao).Include(c => c.motorista);
            return View(cargas.ToList());
        }

        // GET: Cargas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carga carga = db.Cargas.Find(id);
            if (carga == null)
            {
                return HttpNotFound();
            }
            return View(carga);
        }

        // GET: Cargas/Create
        public ActionResult Create()
        {
            ViewBag.CamiaoID = new SelectList(db.Camiaos, "Id", "Modelo");
            ViewBag.MotoristaID = new SelectList(db.Motoristas, "MotoristaID", "Nome");
            return View();
        }

        // POST: Cargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CargaID,data_aquisicao,data_entrega,valor_pago,MotoristaID,CamiaoID,descricao")] Carga carga)
        {
            if (ModelState.IsValid)
            {
                db.Cargas.Add(carga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CamiaoID = new SelectList(db.Camiaos, "Id", "Modelo", carga.CamiaoID);
            ViewBag.MotoristaID = new SelectList(db.Motoristas, "MotoristaID", "Nome", carga.MotoristaID);
            return View(carga);
        }

        // GET: Cargas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carga carga = db.Cargas.Find(id);
            if (carga == null)
            {
                return HttpNotFound();
            }
            ViewBag.CamiaoID = new SelectList(db.Camiaos, "Id", "Modelo", carga.CamiaoID);
            ViewBag.MotoristaID = new SelectList(db.Motoristas, "MotoristaID", "Nome", carga.MotoristaID);
            return View(carga);
        }

        // POST: Cargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CargaID,data_aquisicao,data_entrega,valor_pago,MotoristaID,CamiaoID,descricao")] Carga carga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CamiaoID = new SelectList(db.Camiaos, "Id", "Modelo", carga.CamiaoID);
            ViewBag.MotoristaID = new SelectList(db.Motoristas, "MotoristaID", "Nome", carga.MotoristaID);
            return View(carga);
        }

        // GET: Cargas/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carga carga = db.Cargas.Find(id);
            if (carga == null)
            {
                return HttpNotFound();
            }
            return View(carga);
        }

        // POST: Cargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carga carga = db.Cargas.Find(id);
            db.Cargas.Remove(carga);
            db.SaveChanges();
            return RedirectToAction("Index");
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
