using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface IDetallesDeCompras
    {
        void Insert(DetalleDeCompras DTC);
        void Find(DetalleDeCompras DTC);
        void Delete(DetalleDeCompras DTC);
        void Update(DetalleDeCompras DTC);
        List<DetalleDeCompras> List();
    }
}
