using JustCommerce.Domain.Entities.Products.Manufacturer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Manufacturer
{
    public sealed class ManufacturerEntityTypeConfig : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            builder.ToTable("Manufacturer", "product");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.ManufacturerLang)
                   .WithOne(c => c.Manufacturer)
                   .HasForeignKey(c => c.ManufacturerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProductManufacturer)
                   .WithOne(c => c.Manufacturer)
                   .HasForeignKey(c => c.ManufacturerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
