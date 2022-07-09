using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute
{
    internal sealed class SpecificationAttributeOptionEntityTypeConfig : IEntityTypeConfiguration<SpecificationAttributeOptionEntity>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttributeOptionEntity> builder)
        {
            builder.ToTable("SpecificationAttributeOption", "attribute");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.SpecificationAttribute)
                   .WithMany(c => c.SpecificationAttributeOption)
                   .HasForeignKey(c => c.SpecificationAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.SpecificationAttributeOptionLang)
                   .WithOne(c => c.SpecificationAttributeOption)
                   .HasForeignKey(c => c.SpecificationAttributeOptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProductSpecificationAttribute)
                   .WithOne(c => c.SpecificationAttributeOption)
                   .HasForeignKey(c => c.SpecificationAttributeOptionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
