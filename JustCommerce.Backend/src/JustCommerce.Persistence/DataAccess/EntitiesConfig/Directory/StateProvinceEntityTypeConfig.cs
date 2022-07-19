using JustCommerce.Domain.Entities.Directory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Directory
{
    internal sealed class StateProvinceEntityTypeConfig : IEntityTypeConfiguration<StateProvinceEntity>
    {
        public void Configure(EntityTypeBuilder<StateProvinceEntity> builder)
        {
            builder.ToTable("CheckoutAttribute", "directory");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Country)
                   .WithMany()
                   .HasForeignKey(c => c.CountryId);
        }
    }
}
