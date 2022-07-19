using JustCommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Identity
{
    internal sealed class UserStoreEntityTypeConfig : IEntityTypeConfiguration<UserStoreEntity>
    {
        public void Configure(EntityTypeBuilder<UserStoreEntity> builder)
        {
            builder.ToTable("UserStore", "identity");

            builder.HasKey(c => new { c.StoreId, c.UserId });

            builder.HasOne(c => c.Store)
                   .WithMany(c => c.AllowedUser)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.User)
                   .WithMany(c => c.AllowedStore)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
