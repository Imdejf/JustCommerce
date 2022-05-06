using JustCommerce.Domain.Entities.ShipmentMethod;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.ShipmentMethod
{
    internal sealed class ShipmentMethodLangConfig : IEntityTypeConfiguration<ShipmentMethodLangEntity>
    {
        public void Configure(EntityTypeBuilder<ShipmentMethodLangEntity> builder)
        {
            builder.HasKey(c => new { c.ShipmentMethodId, c.LangaugeId });

            builder.HasOne(c => c.Language)
                   .WithOne()
                   .HasForeignKey<ShipmentMethodLangEntity>(c => c.LangaugeId);

            builder.HasOne(c => c.ShipmentMethod)
                   .WithMany(c => c.ShipmentMethodLang)
                   .HasForeignKey(c => c.ShipmentMethodId);

            builder.Property(c => c.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(true);
        }
    }
}
