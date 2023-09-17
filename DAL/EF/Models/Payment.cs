using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public DateTime Payment_date { get; set; } 


        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public Package Package { get; set; }    
       
      

    }
}
