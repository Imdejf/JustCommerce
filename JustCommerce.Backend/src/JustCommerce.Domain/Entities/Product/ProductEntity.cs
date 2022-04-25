using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Common;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Domain.Entities.Product
{
    public class ProductEntity : AuditableEntity
    {
        public Guid ProductTypeId { get; set; }
        public ProductTypeEntity? ProductType { get; set; }
        public string? MiniaturePhoto { get; set; }
        public string? Slug { get; set; }
        public bool Top { get; set; }
        public bool AvailabilityType { get; set; } //
        public bool Active { get; set; }
        public bool Newsletter { get; set; }
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public ICollection<ProductFileEntity>? ProductFile { get; set; }
        public ICollection<ProductCategoryEntity>? ProductCategory { get; set; }
        public ICollection<ProductLangEntity>? ProductLang { get; set; }
    }
}
