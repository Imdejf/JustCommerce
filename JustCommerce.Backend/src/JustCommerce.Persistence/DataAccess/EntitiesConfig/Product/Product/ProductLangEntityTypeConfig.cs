using JustCommerce.Domain.Entities.Products.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Product
{
    internal sealed class ProductLangEntityTypeConfig : IEntityTypeConfiguration<ProductLangEntity>
    {
        public void Configure(EntityTypeBuilder<ProductLangEntity> builder)
        {
            builder.ToTable("ProductLang", "product");

            builder.HasKey(c => new { c.ProductId, c.LanguageId });

            builder.HasOne(c => c.Product)
                   .WithMany(c => c.ProductLang)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Language)
                    .WithMany()
                    .HasForeignKey(c => c.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
