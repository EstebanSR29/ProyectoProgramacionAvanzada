using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoG6.Controllers
{
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]

    public class CompraController : Controller
    {
        [HttpGet]
        public ActionResult Compra()
        {
            return View();
        }
    }
}