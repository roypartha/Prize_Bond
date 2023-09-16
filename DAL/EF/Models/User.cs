using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class User
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; } = "user";
        public bool IsDelete { get; set; } = false;
        public bool IsBan { get; set;} = false;

        public virtual ICollection<PrizeBond> PrizeBonds { get; set; } = new List<PrizeBond>(); // User 1 - * PrizeBond
        public virtual ICollection<Payment> Payments { get; set; }= new List<Payment>();// User 1 - * Payment
        public virtual ICollection<Premium> Premiums { get; set; } =new List<Premium>();//User 1 - * Premium 
        
    }
}
