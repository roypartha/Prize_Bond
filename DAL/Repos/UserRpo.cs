using DAL.EF;
using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRpo : DataRepository, IAuth<User, bool, string>, IRepo<User, int, bool, string>
    {
        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Create(User obj)
        {
            context.Users.Add(obj);
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            var user = context.Users.Where(u => u.IsDelete == false).SingleOrDefault(u => u.Email.Equals(email));
            return user;
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            var user = context.Users.Where(u => u.IsDelete == false).SingleOrDefault(u => u.UserName.Equals(username));
            return user;
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
