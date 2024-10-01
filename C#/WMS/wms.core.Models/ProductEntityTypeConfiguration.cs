using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace wms.core.Models
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.ProductId);  // Primary key
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Description);
            builder.Property(b => b.Cost).HasColumnType("decimal(18, 2)");
            builder.Property(b => b.Blocked);
            builder.Property(b => b.productCategory);
            builder.Property(b => b.Price).HasColumnType("decimal(18, 2)");
            builder.Property(b => b.Inventory).HasColumnType("decimal(18, 2)");
            
        }
    }
}