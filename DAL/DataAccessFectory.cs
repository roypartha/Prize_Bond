using DAL.EF.Models;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFectory
    {
        public static IAuth<User,bool,string> AuthDataAccess()
        {
            return new UserRpo();
        }
        public static IRepo<User, int, bool, string> UserDataAccess()
        {
            return new UserRpo();
        }
       
    }
}
