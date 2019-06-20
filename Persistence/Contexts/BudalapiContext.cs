
using Microsoft.EntityFrameworkCore;

namespace Budalapi.Persistence.Contexts
{
    public class BudalapiContext : DbContext
    {
        public BudalapiContext(DbContextOptions<BudalapiContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Budalapi.db");
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
    }
}