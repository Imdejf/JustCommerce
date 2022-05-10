using JustCommerce.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Article
{
    internal sealed class ArticleConfig : IEntityTypeConfiguration<ArticleEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleEntity> builder)
        {
            builder.ToTable("Article");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Shop)
                    .WithMany()
                    .HasPrincipalKey(c => c.Id)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired(true);

            builder.HasMany(c => c.ArticleLang)
                   .WithOne(c => c.Article)
                   .HasForeignKey(c => c.ArticleId);

            builder.Property(c => c.Slug)
                   .HasColumnType("varchar")
                   .HasMaxLength(180)
                   .IsRequired();

            builder.Property(c => c.IconPath)
                   .HasColumnType("varchar")
                   .HasMaxLength(500)
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
