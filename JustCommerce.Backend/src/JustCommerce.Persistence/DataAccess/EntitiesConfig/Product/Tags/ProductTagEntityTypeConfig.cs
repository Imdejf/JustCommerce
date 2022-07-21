using JustCommerce.Domain.Entities.Products.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Tags
{
    internal sealed class ProductTagEntityTypeConfig : IEntityTypeConfiguration<ProductTagEntity>
    {
        public void Configure(EntityTypeBuilder<ProductTagEntity> builder)
        {
            builder.ToTable("ProductTag", "product");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Store)
                   .WithMany()
                   .HasForeignKey(c => c.StoreId);

            builder.HasMany(c => c.ProductProductTag)
                   .WithOne(c => c.ProductTag)
                   .HasForeignKey(c => c.ProductTagId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
