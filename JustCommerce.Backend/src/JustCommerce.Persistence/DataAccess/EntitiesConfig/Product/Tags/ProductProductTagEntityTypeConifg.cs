using JustCommerce.Domain.Entities.Products.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Tags
{
    internal sealed class ProductProductTagEntityTypeConifg : IEntityTypeConfiguration<ProductProductTagEntity>
    {
        public void Configure(EntityTypeBuilder<ProductProductTagEntity> builder)
        {
            builder.ToTable("ProductProductTag", "product");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.ProductTag)
                   .WithMany(c => c.ProductProductTag)
                   .HasForeignKey(c => c.ProductTagId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Product)
                   .WithMany(c => c.ProductProductTag)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
