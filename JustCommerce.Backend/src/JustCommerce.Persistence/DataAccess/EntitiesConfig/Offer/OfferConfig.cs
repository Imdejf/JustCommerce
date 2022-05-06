using JustCommerce.Domain.Entities.Offer;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Offer
{
    internal sealed class OfferConfig : IEntityTypeConfiguration<OfferEntity>
    {
        public void Configure(EntityTypeBuilder<OfferEntity> builder)
        {
            builder.ToTable("Offer");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => new { c.Id, c.OfferNumber }).IsUnique(true);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.ShipmentMethod)
                   .WithOne()
                   .HasForeignKey<OfferEntity>(c => c.ShipmentMethodId);

            builder.Property(c => c.AdditionalInfo)
                   .HasColumnType("varchar")
                   .HasMaxLength(2000)
                   .IsRequired(false);

            builder.Property(c => c.CompletionTime)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.CustomerEmail)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.CustomerName)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.CustomerPhone)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.DiffrentShipmentRecipient)
                   .HasColumnType("bit");

            builder.Property(c => c.EInvoice)
                   .HasColumnType("bit");

            builder.Property(c => c.InvoiceRecipientAdress)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRcipientCity)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientCountry)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientName)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientPostalCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientTaxId)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientName)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientCountry)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientCity)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientAdress)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientPostalCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.Note)
                   .HasColumnType("varchar")
                   .HasMaxLength(2000)
                   .IsRequired(false);

            builder.Property(c => c.OfferNumber)
                   .HasColumnType("int")
                   .IsRequired(true);

            builder.Property(c => c.PaymentType)
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentPrice)
                   .HasColumnType("decimal");

            builder.Property(c => c.ItemSumPrice)
                   .HasColumnType("decimal");

            builder.Property(c => c.TotallPrice)
                   .HasColumnType("decimal");

            builder.Property(c => c.SendToClientDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(c => c.OfferSource)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (OfferSource)Enum.Parse(typeof(OfferSource), x, true));

            builder.Property(c => c.OfferStatusType)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (OfferStatusType)Enum.Parse(typeof(OfferStatusType), x, true));

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
        }
    }
}
