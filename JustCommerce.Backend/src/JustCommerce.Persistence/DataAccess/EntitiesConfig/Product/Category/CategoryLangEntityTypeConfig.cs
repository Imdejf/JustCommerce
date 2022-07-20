using JustCommerce.Domain.Entities.Products.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Category
{
    internal sealed class CategoryLangEntityTypeConfig : IEntityTypeConfiguration<CategoryLangEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryLangEntity> builder)
        {
            builder.ToTable("CategoryLang", "product");

            builder.HasKey(c => new { c.CategoryId, c.LanguageId });

            builder.HasOne(c => c.Category)
                   .WithMany(c => c.CategoryLang)
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Language)
                    .WithMany()
                    .HasForeignKey(c => c.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
