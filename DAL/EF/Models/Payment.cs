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
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        [ForeignKey("Premium")]
        public int PremiumId { get; set; }
        public Package Package { get; set; }    
        public Premium Premium { get; set; }
      

    }
}
