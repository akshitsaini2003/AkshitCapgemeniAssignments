using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 75000, CreatedAt = DateTime.Now },
                new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 999, CreatedAt = DateTime.Now },
                new Product { Id = 3, Name = "Office Chair", Category = "Furniture", Price = 8500, CreatedAt = DateTime.Now }
            );

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
