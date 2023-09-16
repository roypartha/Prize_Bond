using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public long Ammount { get; set; }
        public bool isActive { get; set; } = true;

        public virtual ICollection<Payment> Payment { get; set; }   

    }
}
