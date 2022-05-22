using JustCommerce.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product
{
    public sealed class ProductConfig : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.ProductType)
                   .WithMany(c => c.Product)
                   .HasForeignKey(c => c.ProductTypeId);

            builder.HasMany(c => c.ProductSellable)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId);

            builder.HasOne(c => c.Shop)
                   .WithMany()
                   .HasPrincipalKey(c => c.Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(true);

            builder.HasMany(c => c.ProductLang)
                   .WithOne(c => c.Product);

            builder.Property(c => c.MiniaturePhoto)
                   .HasColumnType("varchar(max)");

            builder.Property(c => c.AvailabilityType)
                   .HasColumnType("bit");

            builder.Property(c => c.Newsletter)
                   .HasColumnType("bit");

            builder.Property(c => c.Active)
                   .HasColumnType("bit");

            builder.Property(c => c.Slug)
                   .HasColumnType("varchar")
                   .HasMaxLength(500);

            builder.Property(c => c.Top)
                   .HasColumnType("bit");

            builder.Property(c => c.CreatedBy)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(c => c.LastModifiedBy)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired(false);

            builder.Property(c => c.LastModifiedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);
        }
    }
}
