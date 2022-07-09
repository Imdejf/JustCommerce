using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute
{
    internal sealed class ProductAttributeEntityTypeConfig : IEntityTypeConfiguration<ProductAttributeEntity>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeEntity> builder)
        {
            builder.ToTable("ProductAttribute", "attribute");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.ProductAttributeLang)
                   .WithOne(c => c.ProductAttribute)
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.PredefinedProductAttributeValue)
                   .WithOne(c => c.ProductAttribute)
                   .HasForeignKey(c => c.ProductAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Store)
                   .WithMany()
                   .HasForeignKey(c => c.StoreId);
        }
    }
}
