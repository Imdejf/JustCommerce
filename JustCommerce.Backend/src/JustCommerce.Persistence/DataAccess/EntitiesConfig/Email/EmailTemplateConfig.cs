using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Email
{
    public sealed class EmailTemplateConfig : IEntityTypeConfiguration<EmailTemplateEntity>
    {
        public void Configure(EntityTypeBuilder<EmailTemplateEntity> builder)
        {
            builder.ToTable("EmailTemplate");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Shop)
                   .WithMany()
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(c => c.ShopId);

            builder.HasOne(c => c.EmailAccount)
                   .WithMany(c => c.EmailTemplate)
                   .HasForeignKey(c => c.EmailAccountId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();

            builder.Property(c => c.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(c => c.Actvie)
                   .HasColumnType("bit");

            builder.Property(c => c.FilePath)
                   .HasColumnType("varchar")
                   .HasMaxLength(1000)
                   .IsRequired();

            builder.Property(c => c.Subject)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(c => c.Email)
                   .HasColumnType("varchar")
                   .HasMaxLength(500);

            builder.Property(c => c.EmailName)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(c => c.EmailType)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired()
                   .HasConversion(
                   x => x.ToString(),
                   x => (EmailType)Enum.Parse(typeof(EmailType), x, true));

            builder.Property(c => c.CreatedBy)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();

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
