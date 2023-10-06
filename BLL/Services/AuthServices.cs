﻿using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class AuthServices
    {
        public static TokenDTO Login(string username, string password)
        {
            var data = DataAccessFactory.AuthDataAccess().Authenticate(username, password);


            if (data != null)
            {
                var token = new Token();
                token.UserId = data.Id;
                token.TokenKey = Guid.NewGuid().ToString();
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;

                var userSession = new Session();
                userSession.UserID = data.Id;
                userSession.LoginTime = DateTime.Now;
                userSession.IsActive = true;

                var getToken = DataAccessFactory.TokenDataAccess().Create(token);
                var checkSession = DataAccessFactory.SessionDataAccess().Create(userSession);

                if (checkSession == true && getToken)
                {
                    var mapper = MappingService<Token, TokenDTO>.GetMapper();
                    var rtn = mapper.Map<TokenDTO>(token);
                    return rtn;
                }
                return null;
            }
            return null;
        }

        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().GetAll()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();

            if (tk != null)
            {
                return true;
            }
            return false;
        }
        public static bool IsAdmin(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().GetAll()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      && t.User.Role.Equals("admin")
                      select t).SingleOrDefault();
            return tk != null;
        }

        public static int GetUserID(string token)
        {
            var id = (from t in DataAccessFactory.TokenDataAccess().GetAll()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t.UserId).SingleOrDefault();
            return id;
        }

        public static SessionDTO GetUserActiveSession(int userid)
        {
            var data = DataAccessFactory.SessionDataAccess().GetByID(userid);
            if (data != null)
            {
                var mapper = MappingService<Session, SessionDTO>.GetMapper();
                var rtn = mapper.Map<SessionDTO>(data);
                return rtn;
            }
            return null;
        }
        public static bool ChangeToken(int uid, string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().GetAll()
                      where t.TokenKey.Equals(token)
                      && t.UserId == uid
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();

            var updatetk = false;
            if (tk != null)
            {
                tk.ExpiredAt = DateTime.Now;
                updatetk = DataAccessFactory.TokenDataAccess().Update(tk);
            }
            return updatetk == true;
        }
        public static bool ChangeSession(SessionDTO obj)
        {
            // Creating a new session obj
            var data = new Session
            {
                SessionID = obj.SessionID,
                IsActive = false,
                UserID = obj.UserID,
                LogoutTime = obj.LogoutTime,
                LoginTime = obj.LoginTime
            };

            var rtn = DataAccessFactory.SessionDataAccess().Update(data);
            return rtn == true;
        }
    }
}
