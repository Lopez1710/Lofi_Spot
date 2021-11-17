using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Dominio
{
    public class NumeroCarritos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumeroCarritoID { get; set; }
        public int UsuarioID { get; set; }
        public Usuarios Usuario { get; set; }
        public ICollection<DetalleDeCompras> DetalleDeCompras { get; set; }
        public ICollection<Carritos> Carritos { get; set; }
    }
}
