using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute
{
    internal sealed class PredefinedProductAttributeValueEntityTypeConifg : IEntityTypeConfiguration<PredefinedProductAttributeValueEntity>
    {
        public void Configure(EntityTypeBuilder<PredefinedProductAttributeValueEntity> builder)
        {
            builder.ToTable("PredefinedProductAttributeValue", "attribute");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.ProductAttribute)
                   .WithMany(c => c.PredefinedProductAttributeValue)
                   .HasForeignKey(c => c.ProductAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.PredefinedProductAttributeValueLang)
                   .WithOne(c => c.PredefinedProductAttributeValue)
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
