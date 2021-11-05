using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class CarritosRepository : ICarritos
    {
        private ApplicationDBContext DB;

        public CarritosRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }
        public void Delete(Carritos C)
        {
            DB.Carritos.Remove(C);
            DB.SaveChanges();
        }

        public void Find(Carritos C)
        {
            throw new NotImplementedException();
        }

        public void Insert(Carritos C)
        {
            DB.Carritos.Add(C);
            DB.SaveChanges();
        }

        public List<Carritos> List()
        {
            return DB.Carritos.ToList();
        }

        public void Update(Carritos C)
        {
            DB.Carritos.Update(C);
            DB.SaveChanges();
        }
    }
}
