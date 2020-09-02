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
    public class PEDIDO_DETALLEController : Controller
    {
        private ExiwareEntities1 db = new ExiwareEntities1();

        // GET: PEDIDO_DETALLE
        public ActionResult Index()
        {
            var pEDIDO_DETALLE = db.PEDIDO_DETALLE.Include(p => p.PEDIDO).Include(p => p.PRODUCTO);
            return View(pEDIDO_DETALLE.ToList());
        }

        // GET: PEDIDO_DETALLE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO_DETALLE pEDIDO_DETALLE = db.PEDIDO_DETALLE.Find(id);
            if (pEDIDO_DETALLE == null)
            {
                return HttpNotFound();
            }
            return View(pEDIDO_DETALLE);
        }

        // GET: PEDIDO_DETALLE/Create
        public ActionResult Create()
        {
            ViewBag.ID_PEDIDO = new SelectList(db.PEDIDO, "ID", "ID");
            ViewBag.ID_PRODUCTO = new SelectList(db.PRODUCTO, "ID", "NOMBRE");
            return View();
        }

        // POST: PEDIDO_DETALLE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_PEDIDO,ID_PRODUCTO,PRODUCTO_CANTIDAD")] PEDIDO_DETALLE pEDIDO_DETALLE)
        {
            if (ModelState.IsValid)
            {
                db.PEDIDO_DETALLE.Add(pEDIDO_DETALLE);

                //// agregar metodo para actualizar stock de producto, restandolo del pedido_detalle
                //var sql = "UPDATE PRODUCTO SET PRODUCTO.STOCK = PRODUCTO.STOCK - PRODUCTO_CANTIDAD FROM PRODUCTO WHERE PRODUCTO.ID = PEDIDO_DETALLE.ID_PRODUCTO";


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PEDIDO = new SelectList(db.PEDIDO, "ID", "ID", pEDIDO_DETALLE.ID_PEDIDO);
            ViewBag.ID_PRODUCTO = new SelectList(db.PRODUCTO, "ID", "NOMBRE", pEDIDO_DETALLE.ID_PRODUCTO);
            return View(pEDIDO_DETALLE);
        }

        // GET: PEDIDO_DETALLE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO_DETALLE pEDIDO_DETALLE = db.PEDIDO_DETALLE.Find(id);
            if (pEDIDO_DETALLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PEDIDO = new SelectList(db.PEDIDO, "ID", "ID", pEDIDO_DETALLE.ID_PEDIDO);
            ViewBag.ID_PRODUCTO = new SelectList(db.PRODUCTO, "ID", "NOMBRE", pEDIDO_DETALLE.ID_PRODUCTO);
            return View(pEDIDO_DETALLE);
        }

        // POST: PEDIDO_DETALLE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_PEDIDO,ID_PRODUCTO,PRODUCTO_CANTIDAD")] PEDIDO_DETALLE pEDIDO_DETALLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pEDIDO_DETALLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PEDIDO = new SelectList(db.PEDIDO, "ID", "ID", pEDIDO_DETALLE.ID_PEDIDO);
            ViewBag.ID_PRODUCTO = new SelectList(db.PRODUCTO, "ID", "NOMBRE", pEDIDO_DETALLE.ID_PRODUCTO);
            return View(pEDIDO_DETALLE);
        }

        // GET: PEDIDO_DETALLE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO_DETALLE pEDIDO_DETALLE = db.PEDIDO_DETALLE.Find(id);
            if (pEDIDO_DETALLE == null)
            {
                return HttpNotFound();
            }
            return View(pEDIDO_DETALLE);
        }

        // POST: PEDIDO_DETALLE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PEDIDO_DETALLE pEDIDO_DETALLE = db.PEDIDO_DETALLE.Find(id);
            db.PEDIDO_DETALLE.Remove(pEDIDO_DETALLE);
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
