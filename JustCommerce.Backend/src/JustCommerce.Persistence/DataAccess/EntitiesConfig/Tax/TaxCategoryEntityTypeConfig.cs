using JustCommerce.Domain.Entities.Tax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Tax
{
    internal sealed class TaxCategoryEntityTypeConfig : IEntityTypeConfiguration<TaxCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<TaxCategoryEntity> builder)
        {
            builder.ToTable("TaxCategory", "tax");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.Product)
                   .WithOne(c => c.TaxCategory)
                   .HasForeignKey(c => c.TaxCategoryId);
        }
    }
}
