using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Domain.Entities.ProductType
{
    public sealed class ProductTypeEntity : AuditableEntity
    {
        public string? Name { get; set; }
        public Guid ShopId { get; set; }
        public ShopEntity? Shop { get; set; }
        public ICollection<ProductEntity>? Product { get; set; }
        public ICollection<ProductTypePropertyEntity>? ProductTypeProperty { get; set; }
    }
}
