using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface IDirecciones
    {
        void Insert(Direcciones D);
        void Find(Direcciones D);
        void Delete(Direcciones D);
        void Update(Direcciones D);
        List<Direcciones> List();
    }
}
