using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoG6.BaseDatos;
using ProyectoG6.Entidades;

namespace ProyectoG6.Models
{
    public class ProductoModel
    {
        public List<MostrarProductos_Result> MostrarProductos()
        { 
            using (var context = new ProyectoG6Entities())
            {
                return context.MostrarProductos().ToList();
            }
        }

        public bool AgregarProducto(Producto entidad)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                rowsAffected = context.AgregarProducto(entidad.Nombre, entidad.Precio, entidad.Imagen, entidad.Categoria, entidad.Inventario);
            }

            return (rowsAffected > 0 ? true : false);
        }
        public List<Categorias> ObtenerCategorias()
        {
            using (var context = new ProyectoG6Entities())
            {
                return (from x in context.Categorias
                        select x).ToList();
            }
        }

        public Productos ConsultarProducto(int IdProducto)
        {
            using (var context = new ProyectoG6Entities())
            {
                return (from x in context.Productos
                        where x.IdProducto == IdProducto
                        select x).FirstOrDefault();
            }
        }

        public bool ActualizarProducto(Producto entidad)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                rowsAffected = context.ActualizarProducto(entidad.Nombre, entidad.Precio, entidad.Imagen, entidad.Inventario, entidad.Categoria, entidad.IdProducto);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public bool EliminarProducto(int IdProducto)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                rowsAffected = context.EliminarProducto(IdProducto);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public List<DetallesProducto_Result> DetallesProducto(int IdProducto)
        {
            using (var context = new ProyectoG6Entities())
            {
                return context.DetallesProducto(IdProducto).ToList();
            }
        }

        public List<ObtenerComentarios_Result> ObtenerComentarios(int IdProducto)
        {
            using (var context = new ProyectoG6Entities())
            {
                return context.ObtenerComentarios(IdProducto).ToList();
            }
        }

        public bool Comentar(int IdUsuario, int IdProducto, string Comentariotxt, int Calificacion)
        {

            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                rowsAffected = context.Comentar(IdUsuario, IdProducto, Comentariotxt, Calificacion);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public List<Productos> VistaDinamicaProductos()
        {
            using (var context = new ProyectoG6Entities())
            {
                var productos = context.Productos
                                .OrderBy(p => Guid.NewGuid())
                                .Take(3)
                                .ToList();

                return productos;
            }
        }
    }
}