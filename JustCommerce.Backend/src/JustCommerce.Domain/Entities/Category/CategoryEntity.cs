using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Category
{
    public sealed class CategoryEntity : AuditableEntity
    {
        public string Slug { get; set; }
        public int OrderValue { get; set; }
        public string IconPath { get; set; }
        public ICollection<SubCategoryEntity> SubCategory { get; set; }
        public ICollection<CategoryLangEntity> CategoryLang { get; set; }
    }
}
