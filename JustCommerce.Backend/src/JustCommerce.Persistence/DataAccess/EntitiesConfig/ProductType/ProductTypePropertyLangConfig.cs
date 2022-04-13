using JustCommerce.Domain.Entities.ProductType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.ProductType
{
    public sealed class ProductTypePropertyLangConfig : IEntityTypeConfiguration<ProductTypePropertyLangEntity>
    {
        public void Configure(EntityTypeBuilder<ProductTypePropertyLangEntity> builder)
        {
            builder.ToTable("ProductTypePropertyLang");

            builder.HasKey(c => new { c.ProductTypePropertyId });

            builder.HasOne(c => c.ProductTypeProperty)
                   .WithMany(c => c.ProductTypePropertyLang)
                   .HasForeignKey(c => c.ProductTypePropertyId);

            builder.Property(c => c.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(c => c.DefualtValue)
                   .HasColumnType("varchar")
                   .HasMaxLength(256);

            builder.Property(c => c.DefualtValue)
                   .HasColumnType("varchar")
                   .HasMaxLength(256);

            builder.Property(c => c.IsoCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(6)
                   .IsRequired();
        }
    }
}
