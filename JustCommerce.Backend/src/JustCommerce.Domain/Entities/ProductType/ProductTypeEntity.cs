using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Domain.Entities.ProductType
{
    public sealed class ProductTypeEntity : AuditableEntity
    {
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public Guid ShopId { get; set; }
        public ShopEntity? Shop { get; set; }
        public ICollection<ProductEntity>? Product { get; set; }
        public ICollection<ProductTypePropertyEntity> ProductTypeProperty { get; set; }

        public ProductTypeEntity() { }

        public ProductTypeEntity(string id, string shopId, string name)
        {
            Id = Guid.Parse(id);
            ShopId = Guid.Parse(shopId);
            Name = name;
        }
    }
}
