using ProyectoG6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoG6.Controllers
{
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class ContactoController : Controller
    {
        ContactoModel contactoM = new ContactoModel();

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult Contacto()
        {
            return View();
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult MensajesContacto()
        {
           
            var categorias = contactoM.MensajesContacto();

            return View(categorias);

        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult Responder(int IdContacto)
        {
            var respuesta = contactoM.Responder(IdContacto);
            if (respuesta)
            {
                return RedirectToAction("MensajesContacto", "Contacto");
            }
            return RedirectToAction("MensajesContacto", "Contacto");
        }

        [FiltroSeguridad]
        [HttpPost]
        public ActionResult EnviarMensaje(int IdUsuario, string Asunto, string Mensaje)
        {

            contactoM.EnviarMensaje(IdUsuario, Asunto, Mensaje);
            return RedirectToAction("Contacto","Contacto");
        }
        
    }
}