using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class ImagenesRepository:IImagenes
    {
        private ApplicationDBContext DB;

        public ImagenesRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delete(Imagenes I)
        {
            DB.Imagenes.Remove(I);
            DB.SaveChanges();
        }

        public void Find(Imagenes I)
        {
            throw new NotImplementedException();
        }

        public void Insert(Imagenes I)
        {
            DB.Imagenes.Add(I);
            DB.SaveChanges();
        }

        public List<Imagenes> List()
        {
            return DB.Imagenes.ToList();
        }

        public void Update(Imagenes I)
        {
            DB.Imagenes.Update(I);
            DB.SaveChanges();
        }
    }
}
