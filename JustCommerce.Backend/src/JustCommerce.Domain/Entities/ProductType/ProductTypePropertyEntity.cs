using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Domain.Entities.ProductType
{
    public sealed class ProductTypePropertyEntity : AuditableEntity
    {
        public Guid ProductTypeId { get; set; }
        public ProductTypeEntity? ProductType { get; set; }
        public int OrderValue { get; set; }
        public PropertyType PropertyType { get; set; }
        public ICollection<ProductTypePropertyLangEntity>? ProductTypePropertyLang { get; set; }
    }
}
