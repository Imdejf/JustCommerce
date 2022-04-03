using JustCommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Identity
{
    public sealed class UserClaimConfig : IEntityTypeConfiguration<UserClaimEntity>
    {
        public void Configure(EntityTypeBuilder<UserClaimEntity> builder)
        {
            builder.ToTable("UserClaim", "identity");

            builder.Property(c => c.ClaimValue)
                   .HasColumnType("varchar");

            builder.Property(c => c.ClaimType)
                   .HasColumnType("varchar");
        }
    }
}
