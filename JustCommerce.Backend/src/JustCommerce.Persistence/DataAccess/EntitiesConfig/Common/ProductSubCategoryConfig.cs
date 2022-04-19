using JustCommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Common
{
    public sealed class ProductSubCategoryConfig : IEntityTypeConfiguration<ProductSubCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductSubCategoryEntity> builder)
        {
            builder.ToTable("ProductSubCategory","common");

            builder.HasKey(c => new { c.ProductId, c.SubCategoryId });

            builder.HasOne(pt => pt.Product)
                .WithMany(t => t.ProductSubCategory)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.SubCategory)
                .WithMany(t => t.ProductSubCategory)
                .HasForeignKey(am => am.SubCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
