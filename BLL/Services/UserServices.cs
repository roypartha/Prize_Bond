using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserServices
    {
        public static bool CreateUser(string Name, string Username, string Email,string PhoneNumber, string Pass)
        {

            var resu = DataAccessFactory.AuthDataAccess().GetByUsername(Username);
            var rese = DataAccessFactory.AuthDataAccess().GetByEmail(Email);

            if(resu != null &&  rese !=null)
            {
                return false;
            }
            var UserDto = new UserDTO
            {
                Name = Name,
                UserName = Username,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Password = Pass,
                IsBan = false,
                IsDelete = false
              
            } ;

            var mapper = MappingService<UserDTO, User>.GetMapper();

            var user = mapper.Map<User>(UserDto);
            var userCreated = DataAccessFactory.UserDataAccess().Create(user);

            if(userCreated) {
                return true;
            }
            return false;

        }
    }
}
