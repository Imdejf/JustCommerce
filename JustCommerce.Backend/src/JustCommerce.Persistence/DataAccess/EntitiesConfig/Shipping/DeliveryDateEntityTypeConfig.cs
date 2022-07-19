using JustCommerce.Domain.Entities.Shipping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Shipping
{
    internal sealed class DeliveryDateEntityTypeConfig : IEntityTypeConfiguration<DeliveryDateEntity>
    {
        public void Configure(EntityTypeBuilder<DeliveryDateEntity> builder)
        {
            builder.ToTable("DeliveryDate", "shipping");

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
