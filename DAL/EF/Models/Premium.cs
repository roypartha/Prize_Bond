using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Premium
    {
        [Key]   
        public int Id { get; set; }
        [Required]
        public DateTime CraeteAt { get; set; }= DateTime.Now;
        [Required]
        public DateTime CloseAt { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }//User 1 - * Premium 
       
      

        

     
    }
}
