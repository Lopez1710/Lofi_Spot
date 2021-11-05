using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface ICarritos
    {
        void Insert(Carritos C);
        void Find(Carritos C);
        void Delete(Carritos C);
        void Update(Carritos C);
        List<Carritos> List();
    }
}
