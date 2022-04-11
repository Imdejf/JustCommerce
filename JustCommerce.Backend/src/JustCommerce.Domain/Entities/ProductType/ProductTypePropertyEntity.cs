using JustCommerce.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Domain.Entities.ProductType
{
    public sealed class ProductTypePropertyEntity : AuditableEntity
    {
        public Guid ProductTypeId { get; set; }
        public ProductTypeEntity ProductType { get; set; }
        public string Name { get; set; }

    }
}
