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
    public class PEDIDOesController : Controller
    {
        private ExiwareEntities1 db = new ExiwareEntities1();

        // GET: PEDIDOes
        public ActionResult Index()
        {
            var pEDIDO = db.PEDIDO.Include(p => p.CLIENTE).Include(p => p.EMPLEADO).Include(p => p.SUCURSAL);
            return View(pEDIDO.ToList());
        }

        // GET: PEDIDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDO.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(pEDIDO);
        }

        // GET: PEDIDOes/Create
        public ActionResult Create()
        {
            //ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID", "NOMBRE");
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE.Where(u => u.ESTADO == true), "ID", "NOMBRE");
            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID", "NOMBRE");
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID", "NOMBRE");
            return View();
        }

        // POST: PEDIDOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_SUCURSAL,ID_EMPLEADO,ID_CLIENTE,FECHA")] PEDIDO pEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.PEDIDO.Add(pEDIDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID", "DOCUMENTO", pEDIDO.ID_CLIENTE);        
            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID", "DOCUMENTO", pEDIDO.ID_EMPLEADO);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID", "NOMBRE", pEDIDO.ID_SUCURSAL);
            return View(pEDIDO);
        }

        // GET: PEDIDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDO.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID", "DOCUMENTO", pEDIDO.ID_CLIENTE);
            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID", "DOCUMENTO", pEDIDO.ID_EMPLEADO);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID", "NOMBRE", pEDIDO.ID_SUCURSAL);
            return View(pEDIDO);
        }

        // POST: PEDIDOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_SUCURSAL,ID_EMPLEADO,ID_CLIENTE,FECHA")] PEDIDO pEDIDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pEDIDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID", "DOCUMENTO", pEDIDO.ID_CLIENTE);
            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID", "DOCUMENTO", pEDIDO.ID_EMPLEADO);
            ViewBag.ID_SUCURSAL = new SelectList(db.SUCURSAL, "ID", "NOMBRE", pEDIDO.ID_SUCURSAL);
            return View(pEDIDO);
        }

        // GET: PEDIDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PEDIDO pEDIDO = db.PEDIDO.Find(id);
            if (pEDIDO == null)
            {
                return HttpNotFound();
            }
            return View(pEDIDO);
        }

        // POST: PEDIDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PEDIDO pEDIDO = db.PEDIDO.Find(id);
            db.PEDIDO.Remove(pEDIDO);
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
