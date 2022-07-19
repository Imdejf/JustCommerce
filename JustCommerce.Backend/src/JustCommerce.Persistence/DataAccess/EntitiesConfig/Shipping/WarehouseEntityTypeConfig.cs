using JustCommerce.Domain.Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Shipping
{
    internal sealed class WarehouseEntityTypeConfig : IEntityTypeConfiguration<WarehouseEntity>
    {
        public void Configure(EntityTypeBuilder<WarehouseEntity> builder)
        {
            builder.ToTable("Warehouse", "shipping");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Store)
                   .WithMany()
                   .HasForeignKey(c => c.StoreId);

            builder.HasMany(c => c.ProductWarehouseInventory)
                   .WithOne(c => c.Warehouse)
                   .HasForeignKey(c => c.WarehouseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Adress)
                   .WithMany()
                   .HasForeignKey(c => c.AddressId);
        }
    }
}
