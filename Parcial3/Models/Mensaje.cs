//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parcial3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mensaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mensaje()
        {
            this.DetalleMsg = new HashSet<DetalleMsg>();
        }
    
        public long Id { get; set; }
        public long NroOrigen { get; set; }
        public long NroDestino { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleMsg> DetalleMsg { get; set; }
        public virtual Telefono Telefono { get; set; }
        public virtual Telefono Telefono1 { get; set; }
    }
}
