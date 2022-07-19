using JustCommerce.Domain.Entities.Directory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Directory
{
    internal sealed class CountryEntityTypeConfig : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("Country", "directory");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.Address)
                   .WithOne(c => c.Country)
                   .HasForeignKey(c => c.CountryId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
