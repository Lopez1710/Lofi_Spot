using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class DetalleFactura : IDetalleFactura
    {
        private ApplicationDBContext DB;
        public DetalleFactura(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delet(Dominio.DetalleFactura D)
        {
            throw new NotImplementedException();
        }

        public void insert(Dominio.DetalleFactura D)
        {
            DB.DetalleFactura.Add(D);
            DB.SaveChanges();
        }

        public List<Dominio.DetalleFactura> Listado()
        {
            return DB.DetalleFactura.ToList();
        }
    }
}
