using JustCommerce.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product
{
    public sealed class ProductLangConfig : IEntityTypeConfiguration<ProductLangEntity>
    {
        public void Configure(EntityTypeBuilder<ProductLangEntity> builder)
        {
            builder.ToTable("ProductLang");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Product)
                   .WithMany(c => c.ProductLang)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired(true);

            builder.Property(c => c.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasColumnType("varchar")
                   .HasMaxLength(1000)
                   .IsRequired();

            builder.Property(c => c.MetaTitle)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.MetaDescription)
                   .HasColumnType("varchar")
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(c => c.Synonyms)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.ImageDescription)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.Tags)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.Keywords)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.ProductPropertyJson)
                   .HasColumnType("varchar(max)")
                   .IsRequired(false);

            builder.Property(c => c.IsoCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(6);

            builder.Ignore(c => c.CreatedDate);

            builder.Ignore(c => c.CreatedBy);

            builder.Ignore(c => c.LastModifiedBy);

            builder.Ignore(c => c.LastModifiedDate);
        }
    }
}
