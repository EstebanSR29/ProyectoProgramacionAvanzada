using ProyectoG6.BaseDatos;
using ProyectoG6.Entidades;
using ProyectoG6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoG6.Controllers
{
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class HomeController : Controller
    {
        ProductoModel productoM = new ProductoModel();

        CarritoModel carritoM = new CarritoModel();

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult SobreNosotros()
        {
            return View();
        }
        

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult MostrarProductos(string categoria = null)
        {
            var productos = productoM.MostrarProductos(categoria);

            var categorias = productoM.MenuCat();

            if (categorias == null)
            {
                categorias = new List<string>();
            }

            ViewBag.Categorias = categorias;

            return View(productos);
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

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult DetallesProducto(int IdProducto)
        {
            CargarVariablesCarrito();

            var respuesta = productoM.DetallesProducto(IdProducto);
            
            return View(respuesta);
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult ObtenerComentarios(int IdProducto)
        {
            var respuesta = productoM.ObtenerComentarios(IdProducto);

            ViewBag.IdProducto = IdProducto;

            return View(respuesta);
        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult Comentar(int IdUsuario, int IdProducto, string Comentariotxt, int Calificacion)
        {
            
            var respuesta = productoM.Comentar(IdUsuario, IdProducto, Comentariotxt, Calificacion);

            if (respuesta)
            {
                ViewBag.IdProducto = IdProducto;
                var comentarios = productoM.ObtenerComentarios(IdProducto);
                return View("ObtenerComentarios", comentarios);
            }
               
            else
            {
                ViewBag.msj = "Error al agregar el producto";
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