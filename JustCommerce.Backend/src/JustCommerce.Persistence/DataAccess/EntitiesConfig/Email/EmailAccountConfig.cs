using JustCommerce.Domain.Entities.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Email
{
    public class EmailAccountConfig : IEntityTypeConfiguration<EmailAccountEntity>
    {
        public void Configure(EntityTypeBuilder<EmailAccountEntity> builder)
        {
            builder.ToTable("EmailAccount");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Shop)
                   .WithMany(c => c.EmailAccount)
                   .HasForeignKey(c => c.ShopId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.EmailTemplate)
                   .WithOne(c => c.EmailAccount)
                   .HasForeignKey(c => c.EmailAccountId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(c => c.EmailAddress)
                   .HasColumnType("varchar")
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(c => c.Pop3Prot)
                   .HasColumnType("varchar")
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(c => c.Pop3Server)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.Pop3Login)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.Pop3Password)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.IampProt)
                   .HasColumnType("varchar")
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(c => c.IampServer)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.IampLogin)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.IampPassword)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.SmtpProt)
                   .HasColumnType("varchar")
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(c => c.SmtpServer)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.SmtpLogin)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(c => c.SmtpPassword)
                   .HasColumnType("varchar")
                   .HasMaxLength(100)
                   .IsRequired(false);

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
