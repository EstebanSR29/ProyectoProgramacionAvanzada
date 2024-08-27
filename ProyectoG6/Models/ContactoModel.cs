using ProyectoG6.BaseDatos;
using ProyectoG6.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoG6.Models
{
    public class ContactoModel
    {
        public List<MensajesContacto_Result> MensajesContacto()
        {
            using (var context = new ProyectoG6Entities())
            {
                return context.MensajesContacto().ToList();
            }
        }

        public bool Responder(int IdContacto)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                rowsAffected = context.ResponderMensaje(IdContacto);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public bool EnviarMensaje(int IdUsuario, string Asunto, string Mensaje)
        {
            var rowsAffected = 0;
            using (var context = new ProyectoG6Entities())
            {
                rowsAffected = context.EnviarMensaje(IdUsuario, Asunto, Mensaje);
            }
            return (rowsAffected > 0 ? true : false);
        }
    }
}