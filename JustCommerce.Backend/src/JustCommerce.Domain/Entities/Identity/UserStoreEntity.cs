using JustCommerce.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Entities.Identity
{
    public sealed class UserStoreEntity
    {
        public Guid StoreId { get; set; }
        public StoreEntity Store { get; set; }
        public Guid UserId { get; set; }
        public CMSUserEntity User { get; set; }
    }
}
