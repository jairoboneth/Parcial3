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
    
    public partial class Costo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Costo()
        {
            this.DetalleMsg = new HashSet<DetalleMsg>();
        }
    
        public int CostoId { get; set; }
        public System.TimeSpan HoraCostoInicio { get; set; }
        public System.TimeSpan HoraCostoFin { get; set; }
        public long Valor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleMsg> DetalleMsg { get; set; }
    }
}