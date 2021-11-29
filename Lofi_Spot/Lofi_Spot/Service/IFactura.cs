using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface IFactura
    {
        void insert(Factura F);

        void Delet(Factura F);

        List<Factura> Listado();
    }
}
