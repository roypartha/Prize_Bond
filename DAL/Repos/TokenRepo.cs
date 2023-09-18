using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : DataRepository, IRepo<Token, int, bool, string>
    {
        public bool Create(Token obj)
        {
            try
            {
                context.Tokens.Add(obj);
                int chk = context.SaveChanges();
                return chk > 0;
            }
            catch(Exception) { 
                return false;
            }
           
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Token> GetAll()
        {
            return context.Tokens.ToList();
        }

        public Token GetByID(int id)
        {
            return context.Tokens.Find(id);
        }

        public bool Update(Token obj)
        {

            try
            {
                var tokenInDb = context.Tokens.FirstOrDefault(t => t.Id == obj.Id);
                if (tokenInDb != null)
                {
                    tokenInDb.ExpiredAt = obj.ExpiredAt;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
