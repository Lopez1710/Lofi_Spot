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
        public int DireccionID { get; set; }
        public int CarritoID { get; set; }
        public int UsuarioID { get; set; }
        public Direcciones Direccion { get; set; }
        public Carritos Carrito { get; set; }
        public Usuarios Usuario { get; set; }


    }
}
