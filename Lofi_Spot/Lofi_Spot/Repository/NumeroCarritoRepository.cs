using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class NumeroCarritoRepository:INumeroCarrito
    {
        private ApplicationDBContext DB;
        public NumeroCarritoRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delete(NumeroCarritos NC)
        {
            DB.NumeroCarritos.Remove(NC);
            DB.SaveChanges();
        }

        public void Find(NumeroCarritos NC)
        {
            throw new NotImplementedException();
        }

        public void Insert(NumeroCarritos NC)
        {
            DB.NumeroCarritos.Add(NC);
            DB.SaveChanges();
        }

        public List<NumeroCarritos> List()
        {
            return DB.NumeroCarritos.ToList();
        }

        public void Update(NumeroCarritos NC)
        {
            DB.NumeroCarritos.Update(NC);
            DB.SaveChanges();
        }
    }
}
