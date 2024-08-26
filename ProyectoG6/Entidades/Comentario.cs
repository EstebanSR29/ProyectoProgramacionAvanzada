using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoG6.Entidades
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
        public string Comentariotxt { get; set; }
        public DateTime Fecha { get; set; }
        public int Calificacion { get; set; }
    }
}