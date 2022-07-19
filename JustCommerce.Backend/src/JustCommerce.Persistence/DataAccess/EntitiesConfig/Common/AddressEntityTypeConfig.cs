using JustCommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Common
{
    internal sealed class AddressEntityTypeConfig : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("Address", "common");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Country)
                   .WithMany(c => c.Address)
                   .HasForeignKey(c => c.CountryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.StateProvince)
                   .WithMany(c => c.Address)
                   .HasForeignKey(c => c.StateProvinceId);
        }
    }
}
