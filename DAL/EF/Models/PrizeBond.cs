using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class PrizeBond
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string BondId { get; set; }
        [Required]
        public DateTime CreateAt { get; set;} = DateTime.Now;
        public bool IsDeleted { get; set; }=false;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }// User 1 - * PrizeBond
    }
}
