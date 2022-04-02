using JustCommerce.Domain.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Dictionary
{
    public sealed class DictionaryConfig : IEntityTypeConfiguration<DictionaryEntity>
    {
        public void Configure(EntityTypeBuilder<DictionaryEntity> builder)
        {
            builder.ToTable("Dictionary");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.)
        }
    }
}
