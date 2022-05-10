using JustCommerce.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Article
{
    internal sealed class ArticleRelatedProductConfig : IEntityTypeConfiguration<ArticleRelatedProductEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleRelatedProductEntity> builder)
        {
            builder.ToTable("ArticleRelatedProduct");

            builder.HasKey(c => new { c.ProductId, c.ArticleId });

            builder.HasOne(c => c.Article)
                .WithMany(c => c.ArticleRelatedProduct)
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Product)
                .WithMany(c => c.ArticleRelatedProduct)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
