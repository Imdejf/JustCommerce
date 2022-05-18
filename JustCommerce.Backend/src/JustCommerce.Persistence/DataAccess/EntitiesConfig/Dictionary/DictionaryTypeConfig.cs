using JustCommerce.Domain.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Dictionary
{
    internal sealed class DictionaryTypeConfig : IEntityTypeConfiguration<DictionaryTypeEntity>
    {
        public void Configure(EntityTypeBuilder<DictionaryTypeEntity> builder)
        {
            builder.ToTable("DictionaryType");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => new { c.Id, c.DictionaryType });

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Shop)
                   .WithMany()
                   .HasForeignKey(c => c.ShopId);

            builder.HasMany(c => c.Dictionary)
                   .WithOne(c => c.DictionaryType)
                   .HasForeignKey(c => c.DictionaryTypeId);

            builder.Property(c => c.DictionaryType)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(54)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
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
