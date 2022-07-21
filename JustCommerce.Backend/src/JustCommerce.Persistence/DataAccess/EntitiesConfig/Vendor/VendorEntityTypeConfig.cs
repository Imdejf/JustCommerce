using JustCommerce.Domain.Entities.Vendor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Vendor
{
    internal sealed class VendorEntityTypeConfig : IEntityTypeConfiguration<VendorEntity>
    {
        public void Configure(EntityTypeBuilder<VendorEntity> builder)
        {
            builder.ToTable("Vendor");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.VendorLang)
                   .WithOne(c => c.Vendor)
                   .HasForeignKey(c => c.VendorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Products)
                   .WithOne(c => c.Vendor)
                   .HasForeignKey(c => c.VendorId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Store)
                   .WithMany()
                   .HasForeignKey(c => c.StoreId);

            builder.HasOne(c => c.Address)
                   .WithMany()
                   .HasForeignKey(c => c.AddressId);
        }
    }
}
