
using Budalapi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Budalapi.Persistence.Contexts
{
    public class BudalapiContext : DbContext
    {
        public BudalapiContext(DbContextOptions<BudalapiContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().ToTable("Country");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.Name).HasMaxLength(100);
            //builder.Entity<City>().HasMany(p => p.Products).WithOne(p => p.Country).HasForeignKey(p => p.CountryId);        

            // builder.Entity<Country>().HasData
            // (
            //     new Country { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
            //     new Country { Id = 101, Name = "Dairy" },
            //     new Country { Id = 102, Name = "Butcher" }
            // );

            // builder.Entity<Product>().ToTable("Products");
            // builder.Entity<Product>().HasKey(p => p.Id);
            // builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            // builder.Entity<Product>().Property(p => p.Name).HasMaxLength(50);
            // builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            // builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
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