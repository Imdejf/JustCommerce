using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute.CheckoutAttribute
{
    internal sealed class CheckoutAttributeValueEntityTypeConfig : IEntityTypeConfiguration<CheckoutAttributeValueEntity>
    {
        public void Configure(EntityTypeBuilder<CheckoutAttributeValueEntity> builder)
        {
            builder.ToTable("CheckoutAttributeValue", "attribute");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.CheckoutAttributeValueLang)
                   .WithOne(c => c.CheckoutAttributeValue)
                   .HasForeignKey(c => c.CheckoutAttributeValueId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.CheckoutAttribute)
                   .WithMany(c => c.CheckoutAttributeValue)
                   .HasForeignKey(c => c.CheckoutAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
