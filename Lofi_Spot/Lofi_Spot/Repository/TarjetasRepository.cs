using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class TarjetasRepository:ITarjetas
    {
        private ApplicationDBContext DB;

        public TarjetasRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delete(Tarjetas T)
        {
            DB.Tarjetas.Remove(T);
            DB.SaveChanges();
        }

        public void Find(Tarjetas T)
        {
            throw new NotImplementedException();
        }

        public void Insert(Tarjetas T)
        {
            DB.Tarjetas.Add(T);
            DB.SaveChanges();
        }

        public List<Tarjetas> List()
        {
            return DB.Tarjetas.ToList();
        }

        public void Update(Tarjetas T)
        {
            DB.Tarjetas.Update(T);
            DB.SaveChanges();
        }
    }
}
