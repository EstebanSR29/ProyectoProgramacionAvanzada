﻿using ProyectoG6.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoG6.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(usuario user)
        {
            //validar credenciales para verificar si avanza o no 
            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(usuario user)
        {
            return View();
        }


        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
    }
}