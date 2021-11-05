using Lofi_Spot.Data;
using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Repository
{
    public class RolesRepository:IRoles
    {
        private ApplicationDBContext DB;

        public RolesRepository(ApplicationDBContext DB)
        {
            this.DB = DB;
        }

        public void Delete(Roles R)
        {
            DB.Roles.Remove(R);
            DB.SaveChanges();
        }

        public void Find(Roles R)
        {
            throw new NotImplementedException();
        }

        public void Insert(Roles R)
        {
            DB.Roles.Add(R);
            DB.SaveChanges();
        }

        public List<Roles> List()
        {
            return DB.Roles.ToList();
        }

        public void Update(Roles R)
        {
            DB.Roles.Update(R);
            DB.SaveChanges();
        }
    }
}
