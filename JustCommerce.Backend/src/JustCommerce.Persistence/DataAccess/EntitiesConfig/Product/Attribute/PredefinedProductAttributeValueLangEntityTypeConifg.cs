using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute
{
    internal sealed class PredefinedProductAttributeValueLangEntityTypeConifg : IEntityTypeConfiguration<PredefinedProductAttributeValueLangEntity>
    {
        public void Configure(EntityTypeBuilder<PredefinedProductAttributeValueLangEntity> builder)
        {
            builder.HasKey(c => new { c.PredefinedProductAttributeValueId, c.LanguageId });

            builder.HasOne(c => c.PredefinedProductAttributeValue)
                   .WithMany(c => c.PredefinedProductAttributeValueLang)
                   .HasForeignKey(c => c.PredefinedProductAttributeValueId);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
