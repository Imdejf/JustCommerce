using JustCommerce.Domain.Entities.Products.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Tags
{
    internal sealed class ProductTagLangEntityTypeConfig : IEntityTypeConfiguration<ProductTagLangEntity>
    {
        public void Configure(EntityTypeBuilder<ProductTagLangEntity> builder)
        {
            builder.ToTable("ProductTagLang", "product");

            builder.HasKey(c => new { c.LanguageId, c.ProductTagId });

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ProductTag)
                   .WithMany(c => c.ProductTagLang)
                   .HasForeignKey(c => c.ProductTagId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
