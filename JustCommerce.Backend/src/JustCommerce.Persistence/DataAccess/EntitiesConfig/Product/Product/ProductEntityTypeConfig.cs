using JustCommerce.Domain.Entities.Products.Product;
using JustCommerce.Domain.Enums.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Product
{
    internal sealed class ProductEntityTypeConfig : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product", "product");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.ProductSpecificationAttribute)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.ParentGroupedProduct)
                   .WithOne()
                   .HasForeignKey<ProductEntity>(c => c.ParentGroupedProductId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(false);

            builder.HasOne(c => c.Vendor)
                   .WithMany(c => c.Products)
                   .HasForeignKey(c => c.VendorId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.DeliveryDate)
                   .WithMany(c => c.Product)
                   .HasForeignKey(c => c.DeliveryDateId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.TaxCategory)
                   .WithMany(c => c.Product)
                   .HasForeignKey(c => c.TaxCategoryId);

            builder.HasOne(c => c.ProductAvailabilityRange)
                   .WithMany(c => c.Product)
                   .HasForeignKey(c => c.ProductAvailabilityRangeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.ProductWarehouseInventory)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProductProductTag)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProductManufacturer)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProductCategory)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.GiftCardType)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (GiftCardType)Enum.Parse(typeof(GiftCardType), x, true));

            builder.Property(c => c.RentalPricePeriod)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (RentalPricePeriod)Enum.Parse(typeof(RentalPricePeriod), x, true));

            builder.Property(c => c.ManageInventoryMethod)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (ManageInventoryMethod)Enum.Parse(typeof(ManageInventoryMethod), x, true));

            builder.Property(c => c.LowStockActivity)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (LowStockActivity)Enum.Parse(typeof(LowStockActivity), x, true));  
            
            builder.Property(c => c.BackorderMode)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (BackorderMode)Enum.Parse(typeof(BackorderMode), x, true));

        }
    }
}
