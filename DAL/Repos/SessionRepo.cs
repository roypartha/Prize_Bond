using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SessionRepo : DataRepository, IRepo<Session, int, bool, string>
    {
        public bool Create(Session obj)
        {
            try
            {
                context.Sessions.Add(obj);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Session> GetAll()
        {
            throw new NotImplementedException();
        }

        public Session GetByID(int id)
        {
            try
            {
                var session = context.Sessions.
                    Where(s => s.UserID == id && s.IsActive == true && s.LogoutTime == null)
                    .FirstOrDefault();
                return session;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Session obj)
        {
            try
            {
                var sessionInDb = context.Sessions.FirstOrDefault(s => s.SessionID == obj.SessionID);
                if (sessionInDb != null)
                {
                    sessionInDb.LogoutTime = obj.LogoutTime;
                    sessionInDb.IsActive = obj.IsActive;
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
