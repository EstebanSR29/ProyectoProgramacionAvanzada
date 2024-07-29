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

    }
}