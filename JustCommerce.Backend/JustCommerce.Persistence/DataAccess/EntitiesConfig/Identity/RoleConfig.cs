using JustCommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Identity
{
    public sealed class RoleConfig : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Role", "identity");

            builder.Property(c => c.Name)
                   .HasColumnType("varchar");

            builder.Property(c => c.NormalizedName)
                   .HasColumnType("varchar");
        }
    }
}
