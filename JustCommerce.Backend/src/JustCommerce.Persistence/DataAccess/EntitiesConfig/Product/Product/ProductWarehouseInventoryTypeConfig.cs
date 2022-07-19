using JustCommerce.Domain.Entities.Products.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Product
{
    internal sealed class ProductWarehouseInventoryTypeConfig : IEntityTypeConfiguration<ProductWarehouseInventoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductWarehouseInventoryEntity> builder)
        {
            builder.ToTable("ProductWarehouseInventory", "product");

            builder.HasKey(c => new { c.ProductId, c.WarehouseId });

            builder.HasOne(c => c.Product)
                   .WithMany(c => c.ProductWarehouseInventory)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Warehouse)
                   .WithMany(c => c.ProductWarehouseInventory)
                   .HasForeignKey(c => c.WarehouseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
