using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute.SpecificationAttribute
{
    internal sealed class SpecificationAttributeEntityTypeConfig : IEntityTypeConfiguration<SpecificationAttributeEntity>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttributeEntity> builder)
        {
            builder.ToTable("SpecificationAttribute", "attribute");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.SpecificationAttributeGroup)
                   .WithMany(c => c.SpecificationAttribute)
                   .HasForeignKey(c => c.SpecificationAttributeGroupId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.SpecificationAttributeOption)
                   .WithOne(c => c.SpecificationAttribute)
                   .HasForeignKey(c => c.SpecificationAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
