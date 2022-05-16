using JustCommerce.Domain.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Dictionary
{
    internal sealed class DictionaryConfig : IEntityTypeConfiguration<DictionaryEntity>
    {
        public void Configure(EntityTypeBuilder<DictionaryEntity> builder)
        {
            builder.ToTable("Dictionary");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.DictionaryType)
                   .WithMany(c => c.Dictionary)
                   .HasForeignKey(c => c.DictionaryTypeId);

            builder.HasMany(c => c.DictionaryLang)
                   .WithOne(c => c.Dictionary)
                   .HasForeignKey(c => c.DictionaryId);

            builder.Property(c => c.Name)
                   .HasMaxLength(128)
                   .HasColumnType("varchar")
                   .IsRequired();

            builder.Property(c => c.Dictionary)
                   .HasMaxLength(54)
                   .HasColumnType("varchar")
                   .IsRequired();

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
