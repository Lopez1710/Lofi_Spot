using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface ICategorias
    {
        void Insert(Categorias C);
        void Find(Categorias C);
        void Delete(Categorias C);
        void Update(Categorias C);
        List<Categorias> List();
    }
}
