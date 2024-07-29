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
                Session["ConsecutivoUsuario"] = respuesta.IdUsuario;
                Session["RolUsuario"] = respuesta.IdRol.ToString();
                return RedirectToAction("Home", "Home");
            }
            else
            {
                ViewBag.msj = "Usuario incorrecto o no existe";
                return View();
            }

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

    }
}
