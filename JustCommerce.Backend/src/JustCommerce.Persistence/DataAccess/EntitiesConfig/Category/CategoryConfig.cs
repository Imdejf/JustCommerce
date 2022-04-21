using JustCommerce.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Category
{
    public sealed class CategoryConfig : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.Parent)
                   .WithMany(c => c.ChildCategory)
                   .HasForeignKey(c => c.ParentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.ParentId)
                   .IsRequired(false);

            builder.HasMany(c => c.CategoryLang);
                    
            builder.Property(c => c.OrderValue)
                   .HasColumnType("int");

            builder.Property(c => c.IconPath)
                   .HasMaxLength(1500)
                   .HasColumnType("varchar");

            builder.Property(c => c.Slug)
                   .HasColumnType("varchar")
                   .HasMaxLength(500)
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
