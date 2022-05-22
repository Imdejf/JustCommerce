using JustCommerce.Domain.Entities.Sms;
using JustCommerce.Domain.Enums;
using JustCommerce.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Sms
{
    internal sealed class SmsAccountConfig : IEntityTypeConfiguration<SmsAccountEntity>
    {
        public void Configure(EntityTypeBuilder<SmsAccountEntity> builder)
        {
            builder.ToTable("SmsAccount");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasMany(c => c.SmsTemplate)
                   .WithOne(c => c.SmsAccount)
                   .HasForeignKey(c => c.SmsAccountId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Shop)
                   .WithMany()
                   .HasForeignKey(c => c.ShopId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Token)
                   .HasColumnType("varchar")
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(c => c.From)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.Test)
                   .HasColumnType("bit");

            builder.Property(c => c.CreatedBy)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(c => c.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(c => c.LastModifiedBy)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired(false);

            builder.Property(c => c.LastModifiedDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(c => c.SmsGate)
                   .HasColumnType("varchar")
                   .HasMaxLength(30)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (SmsGate)Enum.Parse(typeof(SmsGate), x, true));

            builder.HasData(SmsAccountSeed.BaseSeed.GetItems());
        }
    }
}
