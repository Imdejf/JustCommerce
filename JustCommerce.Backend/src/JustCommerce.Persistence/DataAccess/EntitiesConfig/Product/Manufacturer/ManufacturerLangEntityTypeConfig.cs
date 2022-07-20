using JustCommerce.Domain.Entities.Products.Manufacturer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Manufacturer
{
    public sealed class ManufacturerLangEntityTypeConfig : IEntityTypeConfiguration<ManufacturerLangEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerLangEntity> builder)
        {
            builder.ToTable("ManufacturerLang", "product");

            builder.HasKey(c => new { c.ManufacturerId, c.LanguageId });

            builder.HasOne(c => c.Manufacturer)
                   .WithMany(c => c.ManufacturerLang)
                   .HasForeignKey(c => c.ManufacturerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Language)
                    .WithMany()
                    .HasForeignKey(c => c.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
