using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Dominio
{
    public class Carritos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarritoID { get; set; }
        public int Cantidad { get; set; }
        public int ProductoID { get; set; }
        public Productos Producto { get; set; }
        public int NumeroCarritoID { get; set; }
        public NumeroCarritos NumeroCarrito { get; set; }
        public int estado { get; set; }
        
    }
}
