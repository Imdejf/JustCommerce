using JustCommerce.Domain.Entities.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Store
{
    internal sealed class StoreEntityTypeConfig : IEntityTypeConfiguration<StoreEntity>
    {
        public void Configure(EntityTypeBuilder<StoreEntity> builder)
        {
            builder.ToTable("Store");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.AllowedUser)
                   .WithOne(c => c.Store)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Language)
                   .WithOne(c => c.Store);
        }
    }
}
