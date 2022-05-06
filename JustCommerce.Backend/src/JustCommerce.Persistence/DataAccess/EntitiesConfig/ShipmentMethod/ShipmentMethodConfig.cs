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
    internal sealed class ShipmentMethodConfig : IEntityTypeConfiguration<ShipmentMethodEntity>
    {
        public void Configure(EntityTypeBuilder<ShipmentMethodEntity> builder)
        {
            builder.ToTable("ShipmentMethod");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.HasMany(c => c.ShipmentMethodLang)
                   .WithOne(c => c.ShipmentMethod)
                   .HasForeignKey(c => c.ShipmentMethodId);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.OrderValue)
                   .HasColumnType("int")
                   .IsRequired(true);

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
