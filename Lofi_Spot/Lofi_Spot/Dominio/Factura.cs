using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Dominio
{

    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacturaID { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroCarritoID { get; set; }
        public NumeroCarritos NumeroCarrito { get; set; }
        public ICollection<DetalleFactura> DetalleFactura { get; set; } 
    }
}
