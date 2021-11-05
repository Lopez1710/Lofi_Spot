using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class DetalleDeComprasRepository:IDetallesDeCompras
    {
        private ApplicationDBContext DB;

        public DetalleDeComprasRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delete(DetalleDeCompras DTC)
        {
            DB.DetalleDeCompras.Remove(DTC);
            DB.SaveChanges();
        }

        public void Find(DetalleDeCompras DTC)
        {
            throw new NotImplementedException();
        }

        public void Insert(DetalleDeCompras DTC)
        {
            DB.DetalleDeCompras.Add(DTC);
            DB.SaveChanges();
        }

        public List<DetalleDeCompras> List()
        {
            return DB.DetalleDeCompras.ToList();
            
        }

        public void Update(DetalleDeCompras DTC)
        {
            DB.DetalleDeCompras.Update(DTC);
            DB.SaveChanges();
        }
    }
}
