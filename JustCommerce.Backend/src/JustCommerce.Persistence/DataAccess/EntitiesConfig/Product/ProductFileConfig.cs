using JustCommerce.Domain.Entities.Product;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product
{
    public sealed class ProductFileConfig : IEntityTypeConfiguration<ProductFileEntity>
    {
        public void Configure(EntityTypeBuilder<ProductFileEntity> builder)
        {
            builder.ToTable("ProductFile");
            
            builder.HasKey(c => new { c.ProductId, c.PhotoPath });

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Product)
                   .WithMany(c => c.ProductFile)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired(true);

            builder.Property(c => c.PhotoPath)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.Property(c => c.ProductColor)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (ProductColor)Enum.Parse(typeof(ProductColor), x, true));

            builder.Ignore(c => c.CreatedDate);

            builder.Ignore(c => c.CreatedBy);

            builder.Ignore(c => c.LastModifiedBy);

            builder.Ignore(c => c.LastModifiedDate);
        }
    }
}
