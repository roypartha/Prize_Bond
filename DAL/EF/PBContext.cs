using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class PBContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PrizeBond> PrizeBonds { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Package> Packages { get; set; }        
    }
}