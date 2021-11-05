using Lofi_Spot.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Service
{
    public interface IImagenes
    {
        void Insert(Imagenes I);
        void Find(Imagenes I);
        void Delete(Imagenes I);
        void Update(Imagenes I);
        List<Imagenes> List();
    }
}
