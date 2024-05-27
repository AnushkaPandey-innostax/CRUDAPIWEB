using Microsoft.EntityFrameworkCore;

namespace CRUDAPIWEB.Models
{
    public class BrandContext : Microsoft.EntityFrameworkCore.DbContext

    {
        public BrandContext(DbContextOptions<BrandContext> options) : base(options) {

        
        }
        public DbSet<brands> Brands { get; set; }
    }
}
