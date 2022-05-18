using JustCommerce.Domain.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Dictionary
{
    internal sealed class DictionaryLangConfig : IEntityTypeConfiguration<DictionaryLangEntity>
    {
        public void Configure(EntityTypeBuilder<DictionaryLangEntity> builder)
        {
            builder.ToTable("DictionaryLang");

            builder.HasKey(c => new { c.DictionaryId, c.LanguageId });

            builder.HasOne(c => c.Language)
                   .WithOne()
                   .HasForeignKey<DictionaryLangEntity>(c => c.LanguageId);

            builder.HasOne(c => c.Dictionary)
                   .WithMany(c => c.DictionaryLang)
                   .HasForeignKey(c => c.DictionaryId);

            builder.Property(c => c.Text)
                   .HasColumnType("varchar")
                   .HasMaxLength(1500)
                   .IsRequired();
        }
    }
}
