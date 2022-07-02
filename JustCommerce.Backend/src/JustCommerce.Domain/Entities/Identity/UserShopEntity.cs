using JustCommerce.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Entities.Identity
{
    public sealed class UserShopEntity
    {
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
