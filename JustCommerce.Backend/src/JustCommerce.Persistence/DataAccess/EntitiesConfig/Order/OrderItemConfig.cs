using JustCommerce.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Order
{
    internal sealed class OrderItemConfig : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(c => new { c.ProductSellableId, c.OrderId });

            builder.HasOne(c => c.ProductSellable)
                   .WithMany(c => c.OrderItem)
                   .HasForeignKey(c => c.ProductSellableId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Order)
                   .WithMany(c => c.OrderItem)
                   .HasForeignKey(c => c.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Quantity)
                   .HasColumnType("int")
                   .IsRequired(true);

            builder.Property(c => c.NettoPrice)
                   .HasColumnType("decimal");

            builder.Property(c => c.GrossPrice)
                   .HasColumnType("decimal");

            builder.Property(c => c.Tax)
                   .HasColumnType("decimal");

            builder.Property(c => c.ProducentPrice)
                   .HasColumnType("decimal");
        }
    }
}
