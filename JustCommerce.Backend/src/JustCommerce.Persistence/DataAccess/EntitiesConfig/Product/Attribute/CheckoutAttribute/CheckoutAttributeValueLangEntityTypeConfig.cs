using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute.CheckoutAttribute
{
    internal class CheckoutAttributeValueLangEntityTypeConfig : IEntityTypeConfiguration<CheckoutAttributeValueLangEntity>
    {
        public void Configure(EntityTypeBuilder<CheckoutAttributeValueLangEntity> builder)
        {
            builder.ToTable("CheckoutAttributeValueLang", "attribute");

            builder.HasKey(c => new { c.CheckoutAttributeValueId, c.LanguageId });

            builder.HasOne(c => c.CheckoutAttributeValue)
                   .WithMany(c => c.CheckoutAttributeValueLang)
                   .HasForeignKey(c => c.CheckoutAttributeValueId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
