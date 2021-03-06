using JustCommerce.Domain.Entities.ProductType;
using JustCommerce.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.ProductType
{
    public sealed class ProductTypeConfig : IEntityTypeConfiguration<ProductTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
        {
            builder.ToTable("ProductType");

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Product)
                   .WithOne(c => c.ProductType)
                   .HasForeignKey(c => c.ProductTypeId);

            builder.HasMany(c => c.ProductTypeProperty)
                   .WithOne(c => c.ProductType);

            builder.HasOne(c => c.Shop)
                   .WithMany()
                   .HasForeignKey(c => c.ShopId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(true);

            builder.Property(c => c.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired();

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

            builder.HasData(ProductTypeSeed.BaseSeed.GetItems());
        }
    }
}
