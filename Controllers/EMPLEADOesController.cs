﻿using System;
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
    public class EMPLEADOesController : Controller
    {
        private ExiwareEntities1 db = new ExiwareEntities1();

        // GET: EMPLEADOes
        public ActionResult Index()
        {
            var eMPLEADO = db.EMPLEADO.Include(e => e.SUCURSAL);
            return View(eMPLEADO.ToList());
        }

        // GET: EMPLEADOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID", "NOMBRE");
            return View();
        }

        // POST: EMPLEADOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DOCUMENTO,NOMBRE,APELLIDO,ID_SUCURSAL")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADO.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID", "NOMBRE", eMPLEADO.ID_SUCURSAL);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID", "NOMBRE", eMPLEADO.ID_SUCURSAL);
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DOCUMENTO,NOMBRE,APELLIDO,ID_SUCURSAL")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID", "NOMBRE", eMPLEADO.ID_SUCURSAL);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            db.EMPLEADO.Remove(eMPLEADO);
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
