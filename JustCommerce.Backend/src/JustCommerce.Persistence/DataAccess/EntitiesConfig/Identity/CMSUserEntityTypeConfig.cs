using JustCommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Identity
{
    internal sealed class CMSUserEntityTypeConfig : IEntityTypeConfiguration<CMSUserEntity>
    {
        public void Configure(EntityTypeBuilder<CMSUserEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.FirstName)
                   .IsRequired(true)
                   .HasMaxLength(300);

            builder.Property(c => c.LastName)
                   .IsRequired(true)
                   .HasMaxLength(300);

            builder.HasMany(c => c.UserPermissions)
                   .WithOne(c => c.User)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.AllowedStore)
                   .WithOne(c => c.User)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
