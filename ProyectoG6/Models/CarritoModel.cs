using ProyectoG6.BaseDatos;
using ProyectoG6.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoG6.Models
{
    public class CarritoModel
    {
        public bool RegistrarCarrito(int IdProducto, int Cantidad)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                int IdUsuario = int.Parse(HttpContext.Current.Session["IdUsuario"].ToString());
                rowsAffected = context.RegistrarCarrito(IdUsuario, IdProducto, Cantidad);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public List<ConsultarCarrito_Result> ConsultarCarrito()
        {
            using (var context = new ProyectoG6Entities())
            {
                int IdUsuario = int.Parse(HttpContext.Current.Session["IdUsuario"].ToString());
                return context.ConsultarCarrito(IdUsuario).ToList();
            }
        }

        public bool PagarCarrito()
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                int IdUsuario = int.Parse(HttpContext.Current.Session["IdUsuario"].ToString());
                rowsAffected = context.PagarCarrito(IdUsuario);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public List<ConsultarFacturas_Result> ConsultarFacturas()
        {
            using (var context = new ProyectoG6Entities())
            {
                int IdUsuario = int.Parse(HttpContext.Current.Session["IdUsuario"].ToString());
                return context.ConsultarFacturas(IdUsuario).ToList();
            }
        }

        public List<FacturaDetalle_Result> FacturaDetalle(int IdUsuario)
        {
            using (var context = new ProyectoG6Entities())
            {
                return context.FacturaDetalle(IdUsuario).ToList();
            }
        }
    }
}