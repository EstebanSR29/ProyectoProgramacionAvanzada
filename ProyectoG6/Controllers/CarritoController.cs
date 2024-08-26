using ProyectoG6.Models;
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
            CargarVariablesCarrito();
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

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult EliminarDelCarrito(int IdCarrito, int IdProducto)
        {

            var respuesta = carritoM.EliminarDelCarrito(IdCarrito, IdProducto);

            if (respuesta)
                return RedirectToAction("ConsultarCarrito", "Carrito");
            else
            {
                ViewBag.msj = "No se logro eliminar el producto del carrito";
                return View();
            }
        }

        private void CargarVariablesCarrito()
        {
            var carritoActual = carritoM.ConsultarCarrito();
            Session["Cantidad"] = carritoActual.Sum(c => c.Cantidad).ToString();
            Session["SubTotal"] = carritoActual.Sum(c => c.Subtotal).ToString();
            Session["Total"] = carritoActual.Sum(c => c.Total).ToString();
        }
    }
}