using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Category;
using JustCommerce.Domain.Entities.Common;
using JustCommerce.Domain.Entities.ProductType;

namespace JustCommerce.Domain.Entities.Product
{
    public class ProductEntity : AuditableEntity
    {
        public Guid ProductTypeId { get; set; }
        public ProductTypeEntity ProductType { get; set; }
        public string Slug { get; set; }
        public bool Top { get; set; }
        public bool AvailabilityType { get; set; } //
        public bool Active { get; set; }
        public bool Newsletter { get; set; }

        public ICollection<ProductCategoryEntity> ProductCategory { get; set; }
        public ICollection<ProductSubCategoryEntity> ProductSubCategory { get; set; }
        public ICollection<ProductLangEntity> ProductLang { get; set; }
    }
}
