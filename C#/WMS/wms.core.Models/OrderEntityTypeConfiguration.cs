using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace wms.core.Models
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(b => b.OrderNo).IsClustered();
            builder.Property(b => b.Type).IsRequired();
            builder.Property(b => b.ExternalDocumentNo).IsRequired();
            builder.Property(b => b.orderStatus).IsRequired();
            builder.Property(b => b.CreatedAt).IsRequired();
            builder.Property(b => b.Createdby).IsRequired();
        }
    }
}