using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute
{
    internal sealed class SpecificationAttributeOptionLangEntityTypeConfig : IEntityTypeConfiguration<SpecificationAttributeOptionLangEntity>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttributeOptionLangEntity> builder)
        {
            builder.ToTable("SpecificationAttributeOptionLang", "attribute");

            builder.HasKey(c => new { c.LanguageId, c.SpecificationAttributeOptionId });

            builder.HasOne(c => c.SpecificationAttributeOption)
                   .WithMany(c => c.SpecificationAttributeOptionLang)
                   .HasForeignKey(c => c.SpecificationAttributeOptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
