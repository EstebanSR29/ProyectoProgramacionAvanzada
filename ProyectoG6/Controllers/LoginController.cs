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
    public class LoginController : Controller
    {
        UsuarioModel usuarioM = new UsuarioModel();

        CarritoModel carritoM = new CarritoModel();

        ProductoModel productoM = new ProductoModel();


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
                Session["NombreUsuario"] = respuesta.Nombre.ToString();
                Session["CorreoUsuario"] = respuesta.Correo;
                Session["IdUsuario"] = respuesta.IdUsuario;
                Session["RolUsuario"] = respuesta.IdRol.ToString();
                CargarVariablesCarrito();
                return RedirectToAction("Home", "Login");
            }
            else
            {
                ViewBag.ErrorMessage = "El correo o la contraseña es incorrecto.";
                return View();
            }

        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult Home()
        {

            CargarVariablesCarrito();
            var respuesta = productoM.VistaDinamicaProductos();

            return View(respuesta);
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
                ViewBag.ErrorMessage = "Ya existe un usuario con ese correo registrado";
                return View();
            }
        }

        [HttpGet]
        public ActionResult RecuperarContrasenna()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarContrasenna(Usuario entidad)
        {

            string Token = usuarioM.CrearToken().ToString();

            bool GuardarToken = usuarioM.GuardarToken(entidad.Correo, Token);

            if (!GuardarToken)
            {
                TempData["ErrorMessage"] = "El correo ingresado no está registrado.";
                return View();
            }

            TempData["SuccessMessage"] = "Se ha enviado un correo electrónico para recuperar su contraseña.";

            return View();

        }

        [HttpGet]
        public ActionResult ValidarToken(string Token)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidarToken(Contrasenna entidad)
        {
            var Token = entidad.Token;
                bool tokenValido = usuarioM.ValidarToken(entidad.Token, entidad.ConfirmarContrasenna);
                    if (tokenValido)
                    {
                        TempData["SuccessMessage"] = "¡Contraseña actualizada!";
                        return View("Index");
                    }
            TempData["ErrorMessage"] = "¡El token expiró, solicite otro!";
            return View();
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

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult PerfilUsuario(int IdUsuario)
        {
            var respuesta = usuarioM.PerfilUsuario(IdUsuario);

            return View(respuesta);
        }


        [FiltroSeguridad]
        [HttpGet]
        public ActionResult CambiarContrasenna()
        {
            return View();
        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult CambiarContrasenna(int IdUsuario, string ContrasennaActual, string NuevaContrasenna, string ConfirmarContrasenna)
        {
            var respuesta = usuarioM.CambiarContrasena(IdUsuario, ContrasennaActual, NuevaContrasenna, ConfirmarContrasenna);

            if (respuesta == false)
            {
              
                ViewBag.ErrorMessage = "Hubo un problema al cambiar la contraseña. Verifique los datos ingresados.";
                return View("CambiarContrasenna");
            }

            return RedirectToAction("PerfilUsuario", "Login", new { IdUsuario = IdUsuario });
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult EditarPerfil(int IdUsuario)
        {
            var respuesta = usuarioM.ConsultarUsuario(IdUsuario);
            return View(respuesta);
        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult EditarPerfil(int IdUsuario, string Nombre, string Correo)
        {
            var respuesta = usuarioM.EditarPerfil(IdUsuario, Nombre, Correo);

            if (respuesta == false)
            {

                TempData["ErrorMessage"] = "El correo ingresado ya está en uso.";
                return RedirectToAction("EditarPerfil", "Login", new { IdUsuario = IdUsuario });
            }

            return RedirectToAction("PerfilUsuario", "Login", new { IdUsuario = IdUsuario });
        }

        
    }
}
