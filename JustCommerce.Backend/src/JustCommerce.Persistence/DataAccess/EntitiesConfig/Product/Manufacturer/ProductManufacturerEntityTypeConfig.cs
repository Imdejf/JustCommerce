using JustCommerce.Domain.Entities.Products.Manufacturer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Manufacturer
{
    public class ProductManufacturerEntityTypeConfig : IEntityTypeConfiguration<ProductManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ProductManufacturerEntity> builder)
        {
            builder.ToTable("ProductManufacturer", "product");

            builder.HasKey(c => new { c.ProductId, c.ManufacturerId });

            builder.HasOne(c => c.Manufacturer)
                   .WithMany(c => c.ProductManufacturer)
                   .HasForeignKey(c => c.ManufacturerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Product)
                   .WithMany(c => c.ProductManufacturer)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
