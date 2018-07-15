using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepositorioGenericoMVC5.Models;
using RepositorioGenericoMVC5.Services;

namespace RepositorioGenericoMVC5.Controllers
{
    public class PersonasController : Controller
    {
        private ApplicationDbContext _applicationDbContext;
        private RepositorioGenericoImp<Persona> _repo;

        public PersonasController()
        {
            _applicationDbContext = new ApplicationDbContext();
            _repo = new RepositorioGenericoImp<Persona>(_applicationDbContext);
        }

        // GET: Personas
        public ActionResult Index()
        {
            //var personas =_applicationDbContext.Personas.Include(x => x.Nacionalidad).ToList();
            var personas = _repo.ObtenerTodos();
            return View(personas);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var persona = _repo.Obtener((int)id);
            
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.IdNacionalidad = new SelectList(_applicationDbContext.Nacionalidades, "Id", "NombreNacionalidad");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,FechaNacimiento,Edad,IdNacionalidad")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _repo.Agregar(persona);
                _repo.Guardar();
                return RedirectToAction("Index");
            }

            ViewBag.IdNacionalidad = new SelectList(_applicationDbContext.Nacionalidades, "Id", "NombreNacionalidad", persona.IdNacionalidad);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = _repo.Obtener((int)id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNacionalidad = new SelectList(_applicationDbContext.Nacionalidades, "Id", "NombreNacionalidad", persona.IdNacionalidad);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,FechaNacimiento,Edad,IdNacionalidad")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(persona);
                _repo.Guardar();
                return RedirectToAction("Index");
            }
            ViewBag.IdNacionalidad = new SelectList(_applicationDbContext.Nacionalidades, "Id", "NombreNacionalidad", persona.IdNacionalidad);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = _repo.Obtener((int)id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = _repo.Obtener((int)id);
            _repo.Eliminar(persona);
            _repo.Guardar();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _applicationDbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
