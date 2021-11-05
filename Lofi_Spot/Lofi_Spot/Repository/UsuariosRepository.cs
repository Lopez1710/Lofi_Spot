using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class UsuariosRepository:IUsuarios
    {
        private ApplicationDBContext DB;

        public UsuariosRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delete(Usuarios U)
        {
            DB.Usuarios.Remove(U);
            DB.SaveChanges();
        }

        public void Find(Usuarios U)
        {
            throw new NotImplementedException();
        }

        public void Insert(Usuarios U)
        {
            DB.Usuarios.Add(U);
            DB.SaveChanges();
        }

        public List<Usuarios> List()
        {
           return DB.Usuarios.ToList();
        }

        public void Update(Usuarios U)
        {
            DB.Usuarios.Update(U);
            DB.SaveChanges();
        }
    }
}
