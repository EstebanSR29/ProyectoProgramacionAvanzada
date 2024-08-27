using ProyectoG6.BaseDatos;
using ProyectoG6.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
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

        public bool CambiarContrasena(int IdUsuario, string ContrasennaActual, string NuevaContrasenna, string ConfirmarContrasenna)
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

        public string CrearToken()
        {
            int length = 6;
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public bool GuardarToken(string Correo, string Token)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                var usuario = context.Usuarios.Where(u => u.Correo == Correo).FirstOrDefault();
                if (usuario != null)
                {
                    usuario.Token = Token;
                    rowsAffected = context.SaveChanges();

                    EnviarCorreo(Correo, Token);
                }
            }

            return (rowsAffected > 0 ? true : false);
        }

        public void EnviarCorreo(string Destino, string Token)
        {
            string cuenta = ConfigurationManager.AppSettings["CuentaCorreo"].ToString();
            string contrasenna = ConfigurationManager.AppSettings["ContrasennaCorreo"].ToString();
            string url = "https://localhost:44357/Login/ValidarToken/?token="+Token;
            MailMessage message = new MailMessage(cuenta, Destino,
                        "Restablecimiento de Contraseña - SPORTSHOP",
                         $@"<html>
                         <body style='font-family: Arial, sans-serif; color: #333;'>
                         <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
                         <h2 style='color: #007BFF;'>Solicitud de Restablecimiento de Contraseña</h2>
                         <p>Hola,</p>
                         <p>Hemos recibido una solicitud para restablecer tu contraseña para tu cuenta en SPORTSHOP. Si no solicitaste este cambio, por favor ignora este mensaje.</p>
                         <p>Para restablecer tu contraseña, haz clic en el siguiente enlace:</p>
                         <p style='text-align: center;'>
                         <a href='{url}' style='display: inline-block; padding: 10px 20px; font-size: 16px; color: #fff; background-color: #007BFF; text-decoration: none; border-radius: 5px;'>Recuperar Contraseña</a>
                            </p>
                        <p>Si tienes problemas con el enlace, copia y pega la siguiente URL en tu navegador:</p>
                        <p><a href='{url}' style='color: #007BFF;'>{url}</a></p>
                        <p>SPORTSHOP</p>
                                </div>
                            </body>
                        </html>");
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(cuenta, contrasenna);
            message.Priority = MailPriority.Normal;            
            client.Send(message);
            client.Dispose();
        }
        public bool ValidarToken(string Token, string ConfirmarContrasenna)
        {
            var rowsAffected = 0;

            using (var context = new ProyectoG6Entities())
            {
                var usuario = context.Usuarios.Where(u => u.Token == Token).FirstOrDefault();

                if (usuario != null)
                {
                    usuario.Contrasenna = ConfirmarContrasenna;
                    usuario.Token = null;
                    rowsAffected = context.SaveChanges();
                }
            }

            return (rowsAffected > 0 ? true : false);
        }

    }
}