using JustCommerce.Domain.Entities.Products.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute
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
