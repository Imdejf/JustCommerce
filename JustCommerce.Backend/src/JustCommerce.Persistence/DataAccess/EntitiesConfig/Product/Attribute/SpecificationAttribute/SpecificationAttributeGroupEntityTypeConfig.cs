using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute.SpecificationAttribute
{
    internal sealed class SpecificationAttributeGroupEntityTypeConfig : IEntityTypeConfiguration<SpecificationAttributeGroupEntity>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttributeGroupEntity> builder)
        {
            builder.ToTable("SpecificationAttributeGroup", "attribute");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Store)
                   .WithMany()
                   .HasForeignKey(c => c.StoreId);

            builder.HasMany(c => c.SpecificationAttribute)
                   .WithOne(c => c.SpecificationAttributeGroup)
                   .HasForeignKey(c => c.SpecificationAttributeGroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
