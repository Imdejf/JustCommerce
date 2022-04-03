using JustCommerce.Domain.Entities.Company;
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
                   .IsRequired();

            builder.Property(c => c.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(c => c.LastModifiedBy)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

            builder.Property(c => c.LastModifiedDate)
                   .HasColumnType("datetime");
        }
    }
}
