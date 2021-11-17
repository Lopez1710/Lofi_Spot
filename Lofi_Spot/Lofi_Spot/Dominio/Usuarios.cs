using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Dominio
{ 
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int RolID { get; set; }
        public Roles Rol { get; set; }
        public int TarjetaID { get; set; }
        public Tarjetas Tarjeta { get; set; }
        public int DireccionID { get; set; }
        public Direcciones Direccion { get; set; }
        public ICollection<NumeroCarritos> NumeroCarritos { get; set; }
        
    }
}
