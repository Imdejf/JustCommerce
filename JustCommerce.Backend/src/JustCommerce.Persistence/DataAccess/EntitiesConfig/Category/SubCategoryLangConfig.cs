using JustCommerce.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Category
{
    public sealed class SubCategoryLangConfig : IEntityTypeConfiguration<SubCategoryLangEntity>
    {
        public void Configure(EntityTypeBuilder<SubCategoryLangEntity> builder)
        {
            builder.ToTable("SubCategoryLang");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasOne(c => c.SubCategory)
                   .WithMany(c => c.SubCategoryLang)
                   .HasForeignKey(c => c.SubCategoryId);

            builder.Property(c => c.Content)
                   .HasColumnType("varchar");

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
