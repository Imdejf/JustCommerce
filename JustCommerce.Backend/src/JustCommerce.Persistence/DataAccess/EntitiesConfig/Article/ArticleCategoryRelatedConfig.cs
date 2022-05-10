using JustCommerce.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Article
{
    internal sealed class ArticleCategoryRelatedConfig : IEntityTypeConfiguration<ArticleCategoryRelatedEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleCategoryRelatedEntity> builder)
        {
            builder.ToTable("ArticleCategoryRelated");

            builder.HasKey(c => new { c.ArticleId, c.CategoryId });

            builder.HasOne(c => c.Article)
                .WithMany(c => c.ArticleCategoryRelated)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Category)
                .WithMany(c => c.ArticleCategoryRelated)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
