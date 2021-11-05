using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface IRoles
    {
        void Insert(Roles R);
        void Find(Roles R);
        void Delete(Roles R);
        void Update(Roles R);
        List<Roles> List();
    }
}
