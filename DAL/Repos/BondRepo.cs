using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BondRepo : DataRepository, IBond<PrizeBond, int, bool, string>
    {
        public bool Create(PrizeBond obj)
        {
            context.PrizeBonds.Add(obj);
            return context.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var res = context.PrizeBonds.SingleOrDefault(b => b.Id == id);
            if(res!= null)
            {
                res.IsDeleted = true;
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public List<PrizeBond> GetAll()
        {
           return context.PrizeBonds.ToList();
        }

        public List<PrizeBond> GetByID(int id)
        {
            return context.PrizeBonds.Where(pb => pb.UserId==id).ToList();
        }

        public bool Update(PrizeBond obj)
        {
            throw new NotImplementedException();
        }
    }
}
