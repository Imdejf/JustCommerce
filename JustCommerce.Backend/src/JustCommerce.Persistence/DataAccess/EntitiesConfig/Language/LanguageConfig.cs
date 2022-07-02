using JustCommerce.Domain.Entities.Language;
using JustCommerce.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Language
{
    internal sealed class LanguageConfig : IEntityTypeConfiguration<LanguageEntity>
    {
        public void Configure(EntityTypeBuilder<LanguageEntity> builder)
        {
            builder.ToTable("Language");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Shop)
                   .WithMany(c => c.Language)
                   .HasForeignKey(c => c.ShopId);

            builder.Property(c => c.NameOrginal)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.NameInternational)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.IsoCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(6)
                   .IsRequired();

            builder.Property(c => c.IsActive)
                   .HasColumnType("bit");

            builder.Property(c => c.DefaultLanguage)
                   .HasColumnType("bit");

            builder.Property(c => c.CreatedBy)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(c => c.LastModifiedBy)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired(false);

            builder.Property(c => c.LastModifiedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.HasData(LanguageSeed.BaseSeed.GetItems());
        }
    }
}
