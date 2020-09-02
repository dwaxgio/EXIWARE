using EXIWARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EXIWARE.Controllers
{
    public class PEDIDO_PEDIDODETALLEController : Controller
    {
        // Controlador creado para unir dos tablas del modelo PEDIDO_PEDIDOViewModel
        public ExiwareEntities1 db = new ExiwareEntities1();
        public ActionResult PedidoPedidoDetalle(Int32? id)
        {
            // obtener pedido por id
            var pedido = (from a in db.PEDIDO
                          where a.ID == id
                          select a).FirstOrDefault();

            // obtener pedido_detalle por id
            var pedidoDetalle = (from a in db.PEDIDO_DETALLE
                                 where a.ID == id
                                 select a).ToList();

            // Output de la informacion al PEDIDO_PEDIDODETALLEViewModel.cs
            var model = new PEDIDO_PEDIDODETALLEViewModel { _PEDIDO = pedido, _PEDIDO_DETALLE = pedidoDetalle };

            return View(model);
        }


        // GET: PEDIDO_PEDIDODETALLE
        public ActionResult Index()
        {
            return View();
        }

        // GET: PEDIDO_PEDIDODETALLE/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PEDIDO_PEDIDODETALLE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PEDIDO_PEDIDODETALLE/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEDIDO_PEDIDODETALLE/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PEDIDO_PEDIDODETALLE/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PEDIDO_PEDIDODETALLE/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PEDIDO_PEDIDODETALLE/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
