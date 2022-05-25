using JustCommerce.Domain.Entities.Order;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Order
{
    internal sealed class OrderConfig : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.OrderNumber);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.HasOne(c => c.Shop)
                   .WithMany()
                   .HasPrincipalKey(c => c.Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(true);

            builder.HasOne(c => c.LanguageVersion)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageVersionId);

            builder.HasOne(c => c.ShipmentMethod)
                   .WithMany()
                   .HasForeignKey(c => c.ShipmentMethodId);

            builder.Property(c => c.MemberId)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipeintName)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceEmail)
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceNumber)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);


            builder.Property(c => c.InvoiceRecipientAddress)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientCity)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientCountry)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientPostalCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientRegion)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.InvoiceRecipientTax)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.Note)
                   .HasColumnType("varchar")
                   .HasMaxLength(1000)
                   .IsRequired(false);

            builder.Property(c => c.AdditionalInfo)
                   .HasColumnType("varchar")
                   .HasMaxLength(1000)
                   .IsRequired(false);

            builder.Property(c => c.CustomerEmail)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.CustomerName)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.CustomerPhone)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.OrderNumber)
                   .HasColumnType("int")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(c => c.ProformaNumber)
                   .HasColumnType("varchar")
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientAddress)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientCity)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientCountry)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientName)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientPostalCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.Property(c => c.ShipmentRecipientRegion)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.DifferentShipmentRecipient)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.Property(c => c.InvoiceEmail)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.Paid)
                   .HasColumnType("bit")
                   .IsRequired();

            builder.Property(c => c.OrderPdf)
                   .HasColumnType("bit");

            builder.Property(c => c.ConfirmOrder)
                   .HasColumnType("bit");

            builder.Property(c => c.Invoice)
                   .HasColumnType("bit");

            builder.Property(c => c.NewsletterAcceptation)
                   .HasColumnType("bit");

            builder.Property(c => c.StatueAcceptation)
                   .HasColumnType("bit");

            builder.Property(c => c.DataProcessingAcceptation)
                   .HasColumnType("bit");

            builder.Property(c => c.FastInvoice)
                   .HasColumnType("bit");

            builder.Property(c => c.PaymentCallSent)
                   .HasColumnType("bit");

            builder.Property(c => c.IncludeShipmentRecipientOnInvoice)
                   .HasColumnType("bit");

            builder.Property(c => c.PaymentReminderSend)
                   .HasColumnType("bit");

            builder.Property(c => c.SmsNotification)
                   .HasColumnType("bit");

            builder.Property(c => c.TradeCreditDays)
                   .HasColumnType("int")
                   .IsRequired(false);

            builder.Property(c => c.PaymentType)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(c => c.TotallPriceGross)
                   .HasColumnType("decimal")
                   .IsRequired();

            builder.Property(c => c.ShipmentPrice)
                   .HasColumnType("decimal")
                   .IsRequired();

            builder.Property(c => c.ItemsSumPriceGross)
                   .HasColumnType("decimal")
                   .IsRequired();

            builder.Property(c => c.PaymentsSum)
                   .HasColumnType("decimal")
                   .IsRequired();

            builder.Property(c => c.PaymentsSum)
                   .HasColumnType("decimal")
                   .IsRequired();

            builder.Property(c => c.Status)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (OrderStatus)Enum.Parse(typeof(OrderStatus), x, true));

            builder.Property(c => c.Source)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (OrderSource)Enum.Parse(typeof(OrderSource), x, true));

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
