//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoG6.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Maestro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maestro()
        {
            this.Detalle = new HashSet<Detalle>();
        }
    
        public int IdMaestro { get; set; }
        public int IdUsuario { get; set; }
        public System.DateTime FechaCompra { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}