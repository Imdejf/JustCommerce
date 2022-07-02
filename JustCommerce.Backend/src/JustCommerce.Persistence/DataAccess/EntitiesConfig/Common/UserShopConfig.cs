using JustCommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Persistence.DataAccess.EntitiesConfig.Common
{
    internal sealed class UserShopConfig : IEntityTypeConfiguration<UserShopEntity>
    {
        public void Configure(EntityTypeBuilder<UserShopEntity> builder)
        {
            builder.ToTable("UserShop", "common");

            builder.HasKey(c => new { c.UserId, c.ShopId });

            builder.HasOne(c => c.User)
                .WithMany(c => c.AllowedShop)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Shop)
                .WithMany(c => c.AllowedUser)
                .HasForeignKey(c => c.ShopId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
