using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMvc.Models;

namespace SalesMvc.Data
{
    public class SalesMvcContext : DbContext
    {
        public DbSet<Department>? Departments { get; set; }
        public DbSet<SalesRecord>? SalesRecords { get; set; }
        public DbSet<Seller>? Sallers { get; set; }

        public SalesMvcContext (DbContextOptions<SalesMvcContext> options)
            : base(options)
        {
        }
    }
}
