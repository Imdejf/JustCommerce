using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Identity
{
    public sealed class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users", "identity");

            builder.HasOne(c => c.Shop)
                   .WithMany(c => c.User)
                   .HasForeignKey(c => c.ShopId)
                   .IsRequired();

            builder.Property(c => c.UserName)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.NormalizedUserName)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(c => c.FirstName)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.LastName)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Email)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.NormalizedEmail)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.PhoneNumber)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(c => c.PhoneNumberConfirmed)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(c => c.PasswordHash)
                   .HasColumnType("varchar(max)")
                   .IsRequired();

            builder.Property(c => c.SecurityStamp)
                   .HasColumnType("varchar(max)");

            builder.Property(c => c.ConcurrencyStamp)
                   .HasColumnType("varchar(max)");

            builder.Property(c => c.RegisterSource)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (UserRegisterSource)Enum.Parse(typeof(UserRegisterSource), x, true));

            builder.Property(c => c.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(c => c.LastModifiedDate)
                   .HasColumnType("datetime");
        }
    }
}
