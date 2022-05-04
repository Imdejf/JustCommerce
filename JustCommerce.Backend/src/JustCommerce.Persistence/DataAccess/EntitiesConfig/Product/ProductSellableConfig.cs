using JustCommerce.Domain.Entities.Product;

using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product
{
    internal sealed class ProductSellableConfig : IEntityTypeConfiguration<ProductSellableEntity>
    {
        public void Configure(EntityTypeBuilder<ProductSellableEntity> builder)
        {
            builder.ToTable("ProductSellable");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Product)
                   .WithMany(c => c.ProductSellable)
                   .HasForeignKey(c => c.ProductId);

            builder.Property(c => c.ProducentPrice)
                   .HasColumnType("decimal")
                   .HasDefaultValue(0.0000)
                   .IsRequired();

            builder.Property(c => c.NettoPrice)
                   .HasColumnType("decimal")
                   .HasDefaultValue(0.0000)
                   .IsRequired();

            builder.Property(c => c.GrossPrice)
                   .HasColumnType("decimal")
                   .HasDefaultValue(0.0000)
                   .IsRequired();

            builder.Property(c => c.OldPrice)
                   .HasColumnType("decimal")
                   .HasDefaultValue(0.0000)
                   .IsRequired();

            builder.Property(c => c.Weight)
                   .HasColumnType("decimal")
                   .HasDefaultValue(0.0000)
                   .IsRequired();

            builder.Property(c => c.ProductNumber)
                   .HasColumnType("varchar")
                   .HasMaxLength(128)
                   .IsRequired(false);

            builder.Property(c => c.EanCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(128)
                   .IsRequired(false);

            builder.Property(c => c.Tax)
                   .HasColumnType("decimal")
                   .IsRequired();

            builder.Property(c => c.IconPath)
                   .HasColumnType("varchar(max)")
                   .IsRequired(false);

            builder.Property(c => c.Currency)
                   .HasColumnType("varchar")
                   .HasMaxLength(10)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (Currency)Enum.Parse(typeof(Currency), x, true));

            builder.Property(c => c.ProductColor)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (ProductColor)Enum.Parse(typeof(ProductColor), x, true));

            builder.Ignore(c => c.CreatedDate);

            builder.Ignore(c => c.CreatedBy);

            builder.Ignore(c => c.LastModifiedBy);

            builder.Ignore(c => c.LastModifiedDate);
        }
    }
}
