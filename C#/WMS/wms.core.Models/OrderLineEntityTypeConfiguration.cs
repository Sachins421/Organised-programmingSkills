using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace wms.core.Models
{
    public class OrderLineEntityTypeConfiguration : IEntityTypeConfiguration<OrderLines>
    {
        public void Configure(EntityTypeBuilder<OrderLines> builder)
        {
            builder.HasKey(b => b.OrderNo);
            builder.HasKey(b => b.LineNo);
            builder.Property(b => b.productId).IsRequired();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.productCategory).IsRequired();
            builder.Property(b => b.Quantity).IsRequired();
            builder.Property(b => b.UnitPrice).IsRequired().HasColumnType("decimal(18, 2)");
            
        }
    }
}