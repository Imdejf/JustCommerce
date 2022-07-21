using JustCommerce.Domain.Entities.Products.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Product.Category
{
    internal class CategoryEntityTypeConfig : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Category", "product");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.ChildCategory)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(false);

            builder.HasOne(c => c.Store)
                   .WithMany()
                   .HasForeignKey(c => c.StoreId);

            builder.HasMany(c => c.CategoryLang)
                   .WithOne(c => c.Category)
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProductCategory)
                   .WithOne(c => c.Category)
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.UpdatedOnUtc)
                   .IsRequired(false);
        }
    }
}
