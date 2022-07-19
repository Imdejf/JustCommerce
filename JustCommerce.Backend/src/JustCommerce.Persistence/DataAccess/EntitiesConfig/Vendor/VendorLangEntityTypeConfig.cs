using JustCommerce.Domain.Entities.Vendor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Vendor
{
    internal sealed class VendorLangEntityTypeConfig : IEntityTypeConfiguration<VendorLangEntity>
    {
        public void Configure(EntityTypeBuilder<VendorLangEntity> builder)
        {
            builder.ToTable("VendorLang");

            builder.HasKey(c => new { c.VendorId, c.LanguageId });

            builder.HasOne(c => c.Vendor)
                   .WithMany(c => c.VendorLang)
                   .HasForeignKey(c => c.VendorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
