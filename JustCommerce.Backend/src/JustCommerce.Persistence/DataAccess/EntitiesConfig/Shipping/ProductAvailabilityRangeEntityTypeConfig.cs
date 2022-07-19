using JustCommerce.Domain.Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Shipping
{
    internal class ProductAvailabilityRangeEntityTypeConfig : IEntityTypeConfiguration<ProductAvailabilityRangeEntity>
    {
        public void Configure(EntityTypeBuilder<ProductAvailabilityRangeEntity> builder)
        {
            builder.ToTable("ProductAvailabilityRange", "shipping");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Store)
                   .WithMany()
                   .HasForeignKey(c => c.StoreId);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
