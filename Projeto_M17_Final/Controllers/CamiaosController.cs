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
    public class CamiaosController : Controller
    {
        private Projeto_M17_FinalContext db = new Projeto_M17_FinalContext();

        // GET: Camiaos
        public ActionResult Index()
        {
            return View(db.Camiaos.ToList());
        }

        // GET: Camiaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiao camiao = db.Camiaos.Find(id);
            if (camiao == null)
            {
                return HttpNotFound();
            }
            return View(camiao);
        }

        // GET: Camiaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camiaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Modelo,Peso,Custo,Estado,Tipo_Camiao")] Camiao camiao)
        {
            if (ModelState.IsValid)
            {
                db.Camiaos.Add(camiao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(camiao);
        }

        // GET: Camiaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiao camiao = db.Camiaos.Find(id);
            if (camiao == null)
            {
                return HttpNotFound();
            }
            return View(camiao);
        }

        // POST: Camiaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Modelo,Peso,Custo,Estado,Tipo_Camiao")] Camiao camiao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camiao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camiao);
        }

        // GET: Camiaos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiao camiao = db.Camiaos.Find(id);
            if (camiao == null)
            {
                return HttpNotFound();
            }
            return View(camiao);
        }

        // POST: Camiaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camiao camiao = db.Camiaos.Find(id);
            db.Camiaos.Remove(camiao);
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
