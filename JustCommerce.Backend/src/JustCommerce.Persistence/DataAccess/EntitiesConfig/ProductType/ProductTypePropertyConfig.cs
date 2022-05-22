using JustCommerce.Domain.Entities.ProductType;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.ProductType
{
    public sealed class ProductTypePropertyConfig : IEntityTypeConfiguration<ProductTypePropertyEntity>
    {
        public void Configure(EntityTypeBuilder<ProductTypePropertyEntity> builder)
        {
            builder.ToTable("ProductTypeProperty");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.ProductType)
                   .WithMany(c => c.ProductTypeProperty)
                   .HasForeignKey(c => c.ProductTypeId);

            builder.HasMany(c => c.ProductTypePropertyLang);

            builder.Property(c => c.OrderValue)
                   .HasColumnType("int");

            builder.Property(c => c.PropertyType)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (PropertyType)Enum.Parse(typeof(PropertyType), x, true));

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
        }
    }
}
