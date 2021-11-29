using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class FacturaRepository : IFactura
    {
        private ApplicationDBContext DB;
        public FacturaRepository(ApplicationDBContext DB) 
        {
            this.DB = DB;
        }

        public void Delet(Factura F)
        {
            DB.Factura.Remove(F);
            DB.SaveChanges();
        }

        public void insert(Factura F)
        {
            DB.Factura.Add(F);
            DB.SaveChanges();
        }

        public List<Factura> Listado()
        {
            return DB.Factura.ToList();
        }
    }
}
