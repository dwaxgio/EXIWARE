using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EXIWARE.Models;

namespace EXIWARE.Controllers
{
    public class SUCURSALsController : Controller
    {
        private ExiwareEntities1 db = new ExiwareEntities1();

        // GET: SUCURSALs
        public ActionResult Index()
        {
            return View(db.SUCURSAL.ToList());
        }

        // GET: SUCURSALs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            if (sUCURSAL == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSAL);
        }

        // GET: SUCURSALs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUCURSALs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,TELEFONO,DIRECCION")] SUCURSAL sUCURSAL)
        {
            if (ModelState.IsValid)
            {
                db.SUCURSAL.Add(sUCURSAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sUCURSAL);
        }

        // GET: SUCURSALs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            if (sUCURSAL == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSAL);
        }

        // POST: SUCURSALs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,TELEFONO,DIRECCION")] SUCURSAL sUCURSAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUCURSAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sUCURSAL);
        }

        // GET: SUCURSALs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            if (sUCURSAL == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSAL);
        }

        // POST: SUCURSALs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            db.SUCURSAL.Remove(sUCURSAL);
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
