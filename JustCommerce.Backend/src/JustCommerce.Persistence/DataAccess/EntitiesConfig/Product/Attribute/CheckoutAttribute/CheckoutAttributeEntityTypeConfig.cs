using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;
using JustCommerce.Domain.Enums.Attribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Attribute.CheckoutAttribute
{
    internal sealed class CheckoutAttributeEntityTypeConfig : IEntityTypeConfiguration<CheckoutAttributeEntity>
    {
        public void Configure(EntityTypeBuilder<CheckoutAttributeEntity> builder)
        {
            builder.ToTable("CheckoutAttribute", "attribute");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Store)
                   .WithMany()
                   .HasForeignKey(c => c.StoreId);

            builder.HasMany(c => c.CheckoutAttributeValue)
                   .WithOne(c => c.CheckoutAttribute)
                   .HasForeignKey(c => c.CheckoutAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(c => c.ConditionAttribute)
                   .WithOne()
                   .HasForeignKey<CheckoutAttributeEntity>(c => c.ConditionAttributeId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(false);

            builder.HasOne(c => c.TaxCategory)
                   .WithMany()
                   .HasForeignKey(c => c.TaxCategoryId)
                   .IsRequired(false);

            builder.Property(c => c.AttributeControlType)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (AttributeControlType)Enum.Parse(typeof(AttributeControlType), x, true));
        }
    }
}
