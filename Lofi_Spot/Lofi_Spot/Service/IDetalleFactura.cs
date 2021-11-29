using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface IDetalleFactura
    {
        void insert(DetalleFactura D);

        List<DetalleFactura> Listado(); 

        void Delet(DetalleFactura D);
    }
}
