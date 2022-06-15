
using Microsoft.EntityFrameworkCore;
using SalesMvc.Models;

namespace SalesMvc.Data
{
    public class SalesMvcContext : DbContext
    {
        public DbSet<Department>? Departments { get; set; }
        public DbSet<SalesRecord>? SalesRecords { get; set; }
        public DbSet<Seller>? Sellers { get; set; }

        public SalesMvcContext (DbContextOptions<SalesMvcContext> options)
            : base(options)
        {
        }
    }
}
