using ProyectoG6.BaseDatos;
using ProyectoG6.Entidades;
using ProyectoG6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoG6.Controllers
{
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class HomeController : Controller
    {
        ProductoModel productoM = new ProductoModel();

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult SobreNosotros()
        {
            return View();
        }
        [FiltroSeguridad]
        [HttpGet]
        public ActionResult Contacto()
        {
            return View();
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult MostrarProductos()
        {
            var respuesta = productoM.MostrarProductos();
            return View(respuesta);
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult AgregarProducto()
        {
            var categorias = productoM.ObtenerCategorias();

            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Categoria");

            return View();
        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult AgregarProducto(Producto entidad)
        {
            var respuesta = productoM.AgregarProducto(entidad);

            if (respuesta == true)
                return RedirectToAction("MostrarProductos", "Home");
            else
            {
                ViewBag.msj = "Error al agregar el producto";
                return View();
            }
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult ActualizarProducto(int IdProducto)
        {
            var respuesta = productoM.ConsultarProducto(IdProducto);

            var categorias = productoM.ObtenerCategorias();

            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Categoria");

            return View(respuesta);
        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult ActualizarProducto(Producto entidad)
        {
            var respuesta = productoM.ActualizarProducto(entidad);

            if (respuesta)
                return RedirectToAction("MostrarProductos", "Home");
            else
            {
                ViewBag.msj = "No se logro actualizar el producto";
                return View();
            }
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult EliminarProducto(int IdProducto)
        {

            var respuesta = productoM.EliminarProducto(IdProducto);

            if (respuesta)
                return RedirectToAction("MostrarProductos", "Home");
            else
            {
                ViewBag.msj = "No se logro eliminar el producto";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Compra()
        {
            return View();
        }

    }
}