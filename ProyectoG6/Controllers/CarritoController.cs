﻿using ProyectoG6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoG6.Controllers
{
    public class CarritoController : Controller
    {
        CarritoModel carritoM = new CarritoModel();

        [HttpGet]
        public ActionResult ConsultarCarrito()
        {
            var datos = carritoM.ConsultarCarrito();
            return View(datos);
        }

        [HttpPost]
        public ActionResult PagarCarrito()
        {
            carritoM.PagarCarrito();
            return RedirectToAction("Home","Login");
        }

        [HttpGet]
        public ActionResult ConsultarFacturas()
        {
            var datos = carritoM.ConsultarFacturas();
            return View(datos);
        }

        [HttpGet]
        public ActionResult FacturaDetalle(int IdUsuario)
        {
            var datos = carritoM.FacturaDetalle(IdUsuario);
            return View(datos);
        }
    }
}