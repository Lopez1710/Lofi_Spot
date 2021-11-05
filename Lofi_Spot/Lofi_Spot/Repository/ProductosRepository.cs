using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class ProductosRepository:IProductos
    {
        private ApplicationDBContext DB;

        public ProductosRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delete(Productos P)
        {
            DB.Productos.Remove(P);
            DB.SaveChanges();
        }

        public void Find(Productos P)
        {
            throw new NotImplementedException();
        }

        public void Insert(Productos P)
        {
            DB.Productos.Add(P);
            DB.SaveChanges();
        }

        public List<Productos> List()
        {
            return DB.Productos.ToList();
        }

        public void Update(Productos P)
        {
            DB.Productos.Update(P);
            DB.SaveChanges();
        }
    }
}
