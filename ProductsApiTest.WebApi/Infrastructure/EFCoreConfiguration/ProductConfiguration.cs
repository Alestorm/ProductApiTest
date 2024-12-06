using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsApiTest.WebApi.Domain.Entities;

namespace ProductsApiTest.WebApi.Infrastructure.EFCoreConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.IdProduct);
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.Price).HasColumnType("decimal(10,2)");
            builder.Property(p => p.CreationDate).HasDefaultValue(DateTime.Now);
        }
    }
}
