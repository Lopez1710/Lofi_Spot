using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface IUsuarios
    {
        void Insert(Usuarios U);
        void Find(Usuarios U);
        void Delete(Usuarios U);
        void Update(Usuarios U);
        List<Usuarios> List();

    }
}
