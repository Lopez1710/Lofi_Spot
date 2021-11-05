using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface IProductos
    {
        void Insert(Productos P);
        void Find(Productos P);
        void Delete(Productos P);
        void Update(Productos P);
        List<Productos> List();
    }
}
