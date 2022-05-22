using JustCommerce.Domain.Entities.Sms;
using JustCommerce.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Sms
{
    internal sealed class SmsTemplateLangConifg : IEntityTypeConfiguration<SmsTemplateLangEntity>
    {
        public void Configure(EntityTypeBuilder<SmsTemplateLangEntity> builder)
        {
            builder.ToTable("SmsTemplateLang");

            builder.HasKey(c => new { c.SmsTemplateId, c.LanguageId });


            builder.HasOne(c => c.SmsTemplate)
                   .WithMany(c => c.SmsTemplateLang)
                   .HasForeignKey(c => c.SmsTemplateId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Text)
                   .HasColumnType("varchar")
                   .HasMaxLength(1000)
                   .IsRequired();

            builder.HasData(SmsTemplateLangSeed.BaseSeed.GetItems());
        }
    }
}
