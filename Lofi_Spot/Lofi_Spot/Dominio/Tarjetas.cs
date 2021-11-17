using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Dominio
{
    public class Tarjetas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarjetaID { get; set; }
        public DateTime Fecha { get; set; }
        public int CVV { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
