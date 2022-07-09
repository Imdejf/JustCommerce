using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Products.Attributes.Common;

namespace JustCommerce.Domain.Entities.Products.Product
{
    public sealed class ProductEntity : Entity
    {
        public ICollection<ProductSpecificationAttributeEntity> ProductSpecificationAttribute { get; set; }  
    }
}
