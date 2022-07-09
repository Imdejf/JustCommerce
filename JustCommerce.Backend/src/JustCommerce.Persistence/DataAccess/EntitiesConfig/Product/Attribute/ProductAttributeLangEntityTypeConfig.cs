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
    internal sealed class ProductAttributeLangEntityTypeConfig : IEntityTypeConfiguration<ProductAttributeLangEntity>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeLangEntity> builder)
        {
            builder.HasKey(c => new { c.LanguageId, c.ProductAttributeId });

            builder.HasOne(c => c.ProductAttribute)
                   .WithMany(c => c.ProductAttributeLang)
                   .HasForeignKey(c => c.ProductAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId);
        }
    }
}
