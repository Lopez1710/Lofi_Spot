using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Dominio
{
    public static class ElementosEstaticos
    {
        public static int IDUser = 0;
        public static int Direccion = 0;
        public static int Tarjeta = 0;
        public static int NumeroCarrito = 0;
        public static int Rol = 0;
        public static int IDProducto = 0;
        public static int NF = 0;
        public static int comprobacion = 0;
        public static string Fecha ="0";
        public static string Hora = "0";


        public static List<Usuarios> usuario;
        public static List<Carritos> carritos;
        public static List<DetalleFactura> DF;
    }
}
