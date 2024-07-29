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
    }
}