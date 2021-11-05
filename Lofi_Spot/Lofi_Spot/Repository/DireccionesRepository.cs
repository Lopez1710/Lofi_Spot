using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class DireccionesRepository:IDirecciones
    {
        private ApplicationDBContext DB;

        public DireccionesRepository (ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delete(Direcciones D)
        {
            DB.Direcciones.Remove(D);
            DB.SaveChanges();
        }

        public void Find(Direcciones D)
        {
            throw new NotImplementedException();
        }

        public void Insert(Direcciones D)
        {
            DB.Direcciones.Add(D);
            DB.SaveChanges();
        }

        public List<Direcciones> List()
        {
            return DB.Direcciones.ToList();
        }

        public void Update(Direcciones D)
        {
            DB.Direcciones.Update(D);
            DB.SaveChanges();
        }
    }
}
