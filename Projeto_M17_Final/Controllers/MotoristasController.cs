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
    public class MotoristasController : Controller
    {
        private Projeto_M17_FinalContext db = new Projeto_M17_FinalContext();

        // GET: Motoristas
        public ActionResult Index()
        {
            return View(db.Motoristas.ToList());
        }

        // GET: Motoristas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        // GET: Motoristas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotoristaID,Nome,Email,Morada,CP,Telefone,DataNascimento")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                db.Motoristas.Add(motorista);
                db.SaveChanges();

                //guardar a fotografia
                HttpPostedFileBase fotografia = Request.Files["fotografia"];
                if (fotografia != null && fotografia.ContentLength > 0)
                {
                    string nome = Server.MapPath("~/Public/") + motorista.MotoristaID + ".jpg";
                    fotografia.SaveAs(nome);
                }

                return RedirectToAction("Index");
            }

            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MotoristaID,Nome,Email,Morada,CP,Telefone,DataNascimento")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motorista);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Motoristas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motorista motorista = db.Motoristas.Find(id);
            db.Motoristas.Remove(motorista);
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
