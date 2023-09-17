using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
       
            
            public int Id { get; set; }      
            public string Name { get; set; }    
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Role { get; set; } = "user";
            public bool IsDelete { get; set; } = false;
            public bool IsBan { get; set; } = false;
         

    }
 }

