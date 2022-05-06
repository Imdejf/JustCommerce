using JustCommerce.Domain.Entities.Offer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Offer
{
    internal sealed class OfferItemConfig : IEntityTypeConfiguration<OfferItemEntity>
    {
        public void Configure(EntityTypeBuilder<OfferItemEntity> builder)
        {
            builder.ToTable("OfferItem");

            builder.HasKey(c => new { c.OfferId, c.ProductSellableId });

            builder.HasOne(c => c.Offer)
                .WithMany(c => c.OfferItem)
                .HasForeignKey(c => c.OfferId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.ProductSellable)
                .WithMany(c => c.OfferItem)
                .HasForeignKey(c => c.ProductSellableId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Quantity)
                   .HasColumnType("int")
                   .IsRequired(true);

            builder.Property(c => c.NettoPrice)
                   .HasColumnType("decimal");

            builder.Property(c => c.GrossPrice)
                   .HasColumnType("decimal");

            builder.Property(c => c.Tax)
                   .HasColumnType("decimal");

            builder.Property(c => c.ProducentPrice)
                   .HasColumnType("decimal");
        }
    }
}
