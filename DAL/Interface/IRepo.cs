using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo<MODELCLASS,NUMBER,LOGIC,OTHERS>
    {
        List<MODELCLASS> GetAll();
        MODELCLASS GetByID(NUMBER id);
        LOGIC Create(MODELCLASS obj);
        LOGIC Delete(NUMBER id);
        LOGIC Update(MODELCLASS obj);
    }
}
