using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class CategoriasRepository : ICategorias
    {
        private ApplicationDBContext DB;

        public CategoriasRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }
        public void Delete(Categorias C)
        {
            DB.Categorias.Remove(C);
            DB.SaveChanges();
        }

        public void Find(Categorias C)
        {
            throw new NotImplementedException();
            
        }

        public void Insert(Categorias C)
        {
            DB.Categorias.Add(C);
            DB.SaveChanges();
        }

        public List<Categorias> List()
        {
            return DB.Categorias.ToList();
        }

        public void Update(Categorias C)
        {
            DB.Categorias.Update(C);
            DB.SaveChanges();
        }
    }
}
