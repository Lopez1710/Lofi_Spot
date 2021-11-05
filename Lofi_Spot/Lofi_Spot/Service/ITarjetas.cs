using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface ITarjetas
    {
        void Insert(Tarjetas T);
        void Find(Tarjetas T);
        void Delete(Tarjetas T);
        void Update(Tarjetas T);
        List<Tarjetas> List();
    }
}
