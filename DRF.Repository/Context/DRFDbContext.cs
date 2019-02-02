using DRF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository.Context
{
    public class DRFDbContext : DbContext
    {
        public DRFDbContext() : base("DRFDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
