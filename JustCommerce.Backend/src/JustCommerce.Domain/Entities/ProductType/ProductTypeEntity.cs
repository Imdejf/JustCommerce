using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.ProductType
{
    public sealed class ProductTypeEntity : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<ProductTypePropertyEntity>? ProductTypeProperty { get; set; }
    }
}
