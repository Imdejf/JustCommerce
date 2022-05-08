using JustCommerce.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Article
{
    internal sealed class ArticleCategoryConfig : IEntityTypeConfiguration<ArticleCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleCategoryEntity> builder)
        {
            builder.ToTable("ArticleCategory");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasMany(c => c.ArticleCategoryLang)
                   .WithOne(c => c.ArticleCategory)
                   .HasForeignKey(c => c.ArticleCategoryId);

            builder.Property(c => c.Slug)
                   .HasColumnType("varchar")
                   .HasMaxLength(180)
                   .IsRequired(true);

            builder.Property(c => c.IconPath)
                   .HasColumnType("varchar")
                   .HasMaxLength(180)
                   .IsRequired(false);

            builder.Property(c => c.Active)
                   .HasColumnType("bit");

            builder.Property(c => c.CreatedBy)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(c => c.LastModifiedBy)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired(false);

            builder.Property(c => c.LastModifiedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);
        }
    }
}
