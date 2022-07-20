using JustCommerce.Domain.Entities.Products.Attributes.Common;
using JustCommerce.Domain.Enums.Attribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute.Common
{
    internal sealed class ProductSpecificationAttributeEntityTypeConfig : IEntityTypeConfiguration<ProductSpecificationAttributeEntity>
    {
        public void Configure(EntityTypeBuilder<ProductSpecificationAttributeEntity> builder)
        {
            builder.ToTable("ProductSpecificationAttribute", "attribute");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.SpecificationAttributeOption)
                   .WithMany(c => c.ProductSpecificationAttribute)
                   .HasForeignKey(c => c.SpecificationAttributeOptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Product)
                   .WithMany(c => c.ProductSpecificationAttribute)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.SpecificationAttributeType)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (SpecificationAttributeType)Enum.Parse(typeof(SpecificationAttributeType), x, true));
        }
    }
}
