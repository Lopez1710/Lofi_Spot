using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Dominio
{

    public class DetalleFactura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetalleFacturaID { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public int FacturaID { get; set; }
        public Factura Factura { get; set; }
    }
}
