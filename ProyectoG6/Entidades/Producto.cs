using System;

namespace ProyectoG6.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Categoria { get; set; }
        public int Inventario { get; set; }
        public int Estado { get; set; }
    }

}