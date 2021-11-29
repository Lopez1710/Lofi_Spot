using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Dominio
{
    public class DetalleDeCompras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetalleID { get; set; }
        public decimal Total { get; set; }
        public int NumeroCarritoID { get; set; }
        public NumeroCarritos NumeroCarrito { get; set; }

    }
}
