using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute
{
    internal sealed class ProductAttributeLangEntityTypeConfig : IEntityTypeConfiguration<ProductAttributeLangEntity>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeLangEntity> builder)
        {
            builder.ToTable("ProductAttributeLang", "attribute");

            builder.HasKey(c => new { c.LanguageId, c.ProductAttributeId });

            builder.HasOne(c => c.ProductAttribute)
                   .WithMany(c => c.ProductAttributeLang)
                   .HasForeignKey(c => c.ProductAttributeId);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
