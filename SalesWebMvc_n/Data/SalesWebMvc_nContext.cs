using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc_n.Models;

namespace SalesWebMvc_n.Data
{
    public class SalesWebMvc_nContext : DbContext
    {
        public SalesWebMvc_nContext (DbContextOptions<SalesWebMvc_nContext> options)
            : base(options)
        {
        }
        //public DbSet<SalesWebMvc_n.Models.Department> Department { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord{ get; set; }
    }
}
