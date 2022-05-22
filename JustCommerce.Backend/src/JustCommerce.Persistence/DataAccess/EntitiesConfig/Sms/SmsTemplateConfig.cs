using JustCommerce.Domain.Entities.Sms;
using JustCommerce.Domain.Enums;
using JustCommerce.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Sms
{
    internal sealed class SmsTemplateConfig : IEntityTypeConfiguration<SmsTemplateEntity>
    {
        public void Configure(EntityTypeBuilder<SmsTemplateEntity> builder)
        {
            builder.ToTable("SmsTemplate");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Shop)
                   .WithMany()
                   .HasForeignKey(c => c.ShopId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.SmsAccount)
                   .WithMany(c => c.SmsTemplate)
                   .HasForeignKey(c => c.SmsAccountId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.SmsTemplateLang)
                   .WithOne(c => c.SmsTemplate)
                   .HasForeignKey(c => c.SmsTemplateId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(100);

            builder.Property(c => c.Active)
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

            builder.Property(c => c.SmsType)
                   .HasColumnType("varchar")
                   .HasMaxLength(30)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (SmsType)Enum.Parse(typeof(SmsType), x, true));

            builder.HasData(SmsTemplateSeed.BaseSeed.GetItems());

        }
    }
}
