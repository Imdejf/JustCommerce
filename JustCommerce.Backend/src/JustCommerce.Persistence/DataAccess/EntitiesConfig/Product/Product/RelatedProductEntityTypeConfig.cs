using JustCommerce.Domain.Entities.Products.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Product
{
    internal sealed class RelatedProductEntityTypeConfig : IEntityTypeConfiguration<RelatedProductEntity>
    {
        public void Configure(EntityTypeBuilder<RelatedProductEntity> builder)
        {
            builder.ToTable("RelatedProduct", "product");

            builder.HasKey(c => new { c.Product1Id, c.Product2Id });

            builder.HasOne(c => c.Product1)
                .WithMany()
                .HasForeignKey(c => c.Product1Id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(true);

            builder.HasOne(c => c.Product2)
                .WithMany()
                .HasForeignKey(c => c.Product2Id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(true);
        }
    }
}
