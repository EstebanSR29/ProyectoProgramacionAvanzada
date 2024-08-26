using ProyectoG6.BaseDatos;
using ProyectoG6.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoG6.Models
{
    public class UsuarioModel
    {
        public bool RegistrarUsuario(Usuario entidad)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                rowsAffected = context.RegistrarUsuario(entidad.Nombre, entidad.Correo, entidad.Contrasena);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public IniciarSesion_Result IniciarSesion(Usuario entidad)
        {
            using (var context = new ProyectoG6Entities())
            {
                return context.IniciarSesion(entidad.Correo, entidad.Contrasena).FirstOrDefault();
            }
        }

        public List<Usuarios> PerfilUsuario(int IdUsuario)
        {
            using (var context = new ProyectoG6Entities())
            {
                return context.Usuarios
                              .Where(u => u.IdUsuario == IdUsuario)
                              .ToList();
            }
        }

        public bool CambiarContrasena(int IdUsuario,string ContrasennaActual, string NuevaContrasenna, string ConfirmarContrasenna)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                var usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);

                if (usuario.Contrasenna == ContrasennaActual && NuevaContrasenna == ConfirmarContrasenna)
                {
                    usuario.Contrasenna = ConfirmarContrasenna;

                    rowsAffected = context.SaveChanges();
                }
            }

            return (rowsAffected > 0 ? true : false);

        }
        public bool EditarPerfil(int IdUsuario, string Nombre, string Correo)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                var usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == IdUsuario);

                bool existeCorreo = context.Usuarios.Any(u => u.Correo == Correo && u.IdUsuario != IdUsuario);

                if (existeCorreo)
                {
                    return false;
                }

                usuario.Nombre = Nombre;
                usuario.Correo = Correo;

                rowsAffected = context.SaveChanges();
            }

            return (rowsAffected > 0 ? true : false);
        }

        public Usuarios ConsultarUsuario(int IdUsuario)
        {
            using (var context = new ProyectoG6Entities())
            {
                return (from x in context.Usuarios
                        where x.IdUsuario == IdUsuario
                        select x).FirstOrDefault();
            }
        }
    }
}