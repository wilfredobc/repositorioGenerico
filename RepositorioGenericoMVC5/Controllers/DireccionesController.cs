using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepositorioGenericoMVC5.Models;

namespace RepositorioGenericoMVC5.Controllers
{
    public class DireccionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Direcciones
        public ActionResult Index()
        {
            return View(db.Direcciones.ToList());
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Direccion")] Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.Direcciones.Add(direcciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(direcciones);
        }

        // GET: Direcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Direccion")] Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direcciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(direcciones);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = db.Direcciones.Find(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direcciones direcciones = db.Direcciones.Find(id);
            db.Direcciones.Remove(direcciones);
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
