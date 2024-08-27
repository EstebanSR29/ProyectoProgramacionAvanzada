namespace ProyectoG6.Entidades
{
    public class Usuario
    {
        public int IdUsuario {  get; set; }
        public string Nombre { get; set; }
        public string Correo {  get; set; }
        public string Contrasena {  get; set; }
        public bool Estado { get; set; }
        public byte IdRol { get; set; }
        public string Token {  get; set; }
    }
}