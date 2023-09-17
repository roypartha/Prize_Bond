using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAuth<MODELCLASS,LOGIC, OTHERS>
    {
        MODELCLASS Authenticate(OTHERS username, OTHERS password);
        MODELCLASS GetByEmail(OTHERS email);
        MODELCLASS GetByUsername(OTHERS username);

        //User Authenticate(string username, string password);
        //User GetByEmail(string email);
        //User GetByUsername(string username);
    }
}
