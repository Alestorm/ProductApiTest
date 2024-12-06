using Microsoft.EntityFrameworkCore;
using ProductsApiTest.WebApi.Domain.Entities;

namespace ProductsApiTest.WebApi.Infrastructure.EFCoreConfiguration
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

    }
}
