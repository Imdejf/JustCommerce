using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Common;

namespace JustCommerce.Domain.Entities.Category
{
    public sealed class CategoryEntity : AuditableEntity
    {
        public string Slug { get; set; }
        public int OrderValue { get; set; }
        public string IconPath { get; set; }
        public ICollection<CategoryLangEntity> CategoryLang { get; set; }
        public ICollection<SubCategoryEntity> SubCategory { get; set; }
        public ICollection<ProductCategoryEntity> ProductCategory { get; set; }
    }
}
