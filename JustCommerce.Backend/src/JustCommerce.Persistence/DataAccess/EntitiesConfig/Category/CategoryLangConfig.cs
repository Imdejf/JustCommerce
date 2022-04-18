using JustCommerce.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Category
{
    public sealed class CategoryLangConfig : IEntityTypeConfiguration<CategoryLangEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryLangEntity> builder)
        {
            builder.ToTable("CategoryLang");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Category)
                   .WithMany(c => c.CategoryLang)
                   .HasForeignKey(c => c.CategoryId);

            builder.Property(c => c.Content)
                   .HasColumnType("varchar(max)");

            builder.Property(c => c.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(c => c.Keywords)
                   .HasColumnType("varchar")
                   .HasMaxLength(2000);

            builder.Property(c => c.Description)
                   .HasColumnType("varchar")
                   .HasMaxLength(5000);


            builder.Property(c => c.IsoCode)
                   .HasColumnType("varchar")
                   .HasMaxLength(6)
                   .IsRequired();

            builder.Ignore(c => c.CreatedDate);

            builder.Ignore(c => c.CreatedBy);

            builder.Ignore(c => c.LastModifiedBy);

            builder.Ignore(c => c.LastModifiedDate);
        }
    }
}
