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
    
    public partial class Telefonodesvio
    {
        public long DesvioId { get; set; }
        public long DesvioInicial { get; set; }
        public long DesvioFinal { get; set; }
    
        public virtual Telefono Telefono { get; set; }
        public virtual Telefono Telefono1 { get; set; }
    }
}
