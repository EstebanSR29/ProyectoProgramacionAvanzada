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
    public class LoginController : Controller
    {
        UsuarioModel usuarioM = new UsuarioModel();

        CarritoModel carritoM = new CarritoModel();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario entidad)
        {
            var respuesta = usuarioM.IniciarSesion(entidad);

            if (respuesta != null)
            {
                Session["NombreUsuario"] = respuesta.Nombre;
                Session["IdUsuario"] = respuesta.IdUsuario;
                Session["RolUsuario"] = respuesta.IdRol.ToString();
                CargarVariablesCarrito();
                return RedirectToAction("Home", "Login");
            }
            else
            {
                ViewBag.msj = "Usuario incorrecto o no existe";
                return View();
            }

        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult Home()
        {
            CargarVariablesCarrito();
            return View();
        }


        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Usuario entidad)
        {
            var respuesta = usuarioM.RegistrarUsuario(entidad);

            if (respuesta == true)
                return RedirectToAction("Index", "Login");
            else
            {
                ViewBag.msj = "Ya existe un usuario con ese correo registrado";
                return View();
            }
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult RegistrarCarrito(int IdProducto, int Cantidad)
        {
            carritoM.RegistrarCarrito(IdProducto, Cantidad);

            CargarVariablesCarrito();

            return Json("", JsonRequestBehavior.AllowGet);
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
