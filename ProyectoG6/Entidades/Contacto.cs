using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoG6.Entidades
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public int IdUsuario { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}