using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Common;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Category
{
    public sealed class CategoryEntity : AuditableEntity
    {
        public string Slug { get; set; }
        public int OrderValue { get; set; }
        public string IconPath { get; set; }
        public Guid? ParentId { get; set; }
        public CategoryEntity Parent { get; set; }
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public ICollection<CategoryEntity> ChildCategory { get; set; }
        public ICollection<CategoryLangEntity> CategoryLang { get; set; }
        public ICollection<ProductCategoryEntity> ProductCategory { get; set; }
    }
}
