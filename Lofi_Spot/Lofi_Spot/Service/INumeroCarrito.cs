using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface INumeroCarrito
    {
        void Insert(NumeroCarritos NC);
        void Find(NumeroCarritos NC);
        void Delete(NumeroCarritos NC);
        void Update(NumeroCarritos NC);
        List<NumeroCarritos> List();
    }
}
