using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcial3.Models;

namespace Parcial3.Controllers
{
    public class TelefonoController : Controller
    {
        private AguacateEntities db = new AguacateEntities();

        // GET: Telefono
        public ActionResult Index()
        {
            var telefono = db.Telefono.Include(t => t.Personas);
            return View(telefono.ToList());
        }

        // GET: Telefono/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: Telefono/Create
        public ActionResult Create()
        {
            ViewBag.Cedula = new SelectList(db.Personas, "Cedula", "Nombre");
            return View();
        }

        // POST: Telefono/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Telefono1,Cedula,Saldo,Estado,Desvio")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Telefono.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cedula = new SelectList(db.Personas, "Cedula", "Nombre", telefono.Cedula);
            return View(telefono);
        }

        // GET: Telefono/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cedula = new SelectList(db.Personas, "Cedula", "Nombre", telefono.Cedula);
            return View(telefono);
        }

        // POST: Telefono/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Telefono1,Cedula,Saldo,Estado,Desvio")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cedula = new SelectList(db.Personas, "Cedula", "Nombre", telefono.Cedula);
            return View(telefono);
        }

        // GET: Telefono/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Telefono telefono = db.Telefono.Find(id);
            var cedu = telefono.Cedula;
            int count = db.Telefono.Where(x => x.Cedula == cedu).Count();

            if (count >= 2)
            {

                db.Telefono.Remove(telefono);
                
                db.SaveChanges();

            }
            else
            {
                if (count == 1) {
                    Personas personas = db.Personas.Find(cedu);
                    var ms = (from mensaje in db.Mensaje
                                where mensaje.NroOrigen == telefono.Telefono1 
                                select mensaje).FirstOrDefault();

                    var dt = (from dta in db.DetalleMsg
                              where dta.Mensaje == ms.Id
                              select dta).ToList<DetalleMsg>();

                    var ddasdt = (from banco in db.Banco
                              where banco.Cedula == personas.Cedula
                              select banco).FirstOrDefault();

                    db.DetalleMsg.RemoveRange(dt);
                    db.Mensaje.Remove(ms);
                    db.Telefono.Remove(telefono);
                    db.Banco.Remove(ddasdt);
                    db.Personas.Remove(personas);
                    db.SaveChanges();
                }
            }
            // db.Telefono.Remove(telefono);
            // db.SaveChanges();
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
