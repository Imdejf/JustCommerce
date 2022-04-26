using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Shop
{
    public sealed class ShopConfig : IEntityTypeConfiguration<ShopEntity>
    {
        public void Configure(EntityTypeBuilder<ShopEntity> builder)
        {
            builder.ToTable("Shop");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.User)
                   .WithOne(c => c.Shop)
                   .HasForeignKey(c => c.ShopId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.Email)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(c => c.Name)
                   .HasMaxLength(100)
                   .HasColumnType("varchar")
                   .IsRequired();

            builder.Property(c => c.Zip)
                .HasMaxLength(12)
                .HasColumnType("varchar");

            builder.Property(c => c.State)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(c => c.Country)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(c => c.AddressLine)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.Property(c => c.FullName)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.Property(c => c.City)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(c => c.Active)
                .HasColumnType("bit");

            builder.HasMany(c => c.EmailAccount)
                   .WithOne(c => c.Shop)
                   .HasForeignKey(c => c.ShopId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.CreatedBy)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(c => c.LastModifiedBy)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired(false);

            builder.Property(c => c.LastModifiedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.HasData(ShopSeed.BaseSeed.GetItems());
        }
    }
}
