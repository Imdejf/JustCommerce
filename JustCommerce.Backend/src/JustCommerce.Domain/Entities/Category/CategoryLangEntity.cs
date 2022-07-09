using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Category
{
    public sealed class CategoryLangEntity : Entity
    {
        public Guid? CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
    }
}
