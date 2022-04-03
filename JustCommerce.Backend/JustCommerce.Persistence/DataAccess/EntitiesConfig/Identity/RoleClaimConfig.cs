using JustCommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Identity
{
    public sealed class RoleClaimConfig : IEntityTypeConfiguration<RoleClaimEntity>
    {
        public void Configure(EntityTypeBuilder<RoleClaimEntity> builder)
        {
            builder.ToTable("RoleClaim", "identity");

            builder.Property(c => c.ClaimType)
                   .HasColumnType("varchar");

            builder.Property(c => c.ClaimValue)
                   .HasColumnType("varchar");
        }
    }
}
