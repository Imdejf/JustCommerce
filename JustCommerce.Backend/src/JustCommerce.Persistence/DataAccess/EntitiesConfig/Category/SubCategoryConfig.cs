using JustCommerce.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Category
{
    public sealed class SubCategoryConfig : IEntityTypeConfiguration<SubCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
        {
            builder.ToTable("SubCategory");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Category)
                   .WithMany(c => c.SubCategory)
                   .HasForeignKey(c => c.CategoryId);

            builder.HasMany(c => c.SubCategoryLang);

            builder.Property(c => c.OrderValue)
                   .HasColumnType("int");

            builder.Property(c => c.IconPath)
                   .HasColumnType("varchar");

            builder.Property(c => c.Slug)
                   .HasColumnType("varchar")
                   .IsRequired();

            builder.Property(c => c.CreatedBy)
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .IsRequired(false);

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
