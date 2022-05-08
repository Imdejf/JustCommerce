using JustCommerce.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Article
{
    internal sealed class ArticleLangConfig : IEntityTypeConfiguration<ArticleLangEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleLangEntity> builder)
        {
            builder.ToTable("ArticleLang");

            builder.HasKey(c => new { c.ArticleId, c.LanguageId });

            builder.HasOne(c => c.Article)
                   .WithMany(c => c.ArticleLang)
                   .HasForeignKey(c => c.ArticleId);

            builder.HasOne(c => c.Language)
                   .WithOne()
                   .HasForeignKey<ArticleLangEntity>(c => c.LanguageId);

            builder.Property(c => c.ShortContent)
                   .HasColumnType("varchar")
                   .HasMaxLength(400)
                   .IsRequired(false);

            builder.Property(c => c.Content)
                   .HasColumnType("varchar(max)")
                   .IsRequired(false);

            builder.Property(c => c.KeyWords)
                   .HasColumnType("varchar")
                   .HasMaxLength(255)
                   .IsRequired(false);


            builder.Property(c => c.Description)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired(false);


            builder.Property(c => c.Title)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired(false);


            builder.Property(c => c.MetaDescription)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired(false);
        }
    }
}
