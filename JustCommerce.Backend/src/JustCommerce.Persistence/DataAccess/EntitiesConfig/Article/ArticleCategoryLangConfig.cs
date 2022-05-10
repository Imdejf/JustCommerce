using JustCommerce.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Article
{
    internal sealed class ArticleCategoryLangConfig : IEntityTypeConfiguration<ArticleCategoryLangEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleCategoryLangEntity> builder)
        {
            builder.ToTable("ArticleCategoryLang");

            builder.HasKey(c => new { c.ArticleCategoryId, c.LanguageId });

            builder.HasOne(c => c.ArticleCategory)
                   .WithMany(c => c.ArticleCategoryLang)
                   .HasForeignKey(c => c.ArticleCategoryId);

            builder.HasOne(c => c.Language)
                   .WithOne()
                   .HasForeignKey<ArticleCategoryLangEntity>(c => c.LanguageId);

            builder.Property(c => c.Title)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired(true);

            builder.Property(c => c.MetaTitle)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired(false);

            builder.Property(c => c.Content)
                   .HasColumnType("varchar(max)")
                   .IsRequired(false);

            builder.Property(c => c.MetaDescription)
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(false);
        }
    }
}
