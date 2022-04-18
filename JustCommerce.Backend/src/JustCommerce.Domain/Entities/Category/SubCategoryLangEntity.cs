using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Category
{
    public sealed class SubCategoryLangEntity : AuditableEntity
    {
        public Guid SubCategoryId { get; set; }
        public SubCategoryEntity SubCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public string IsoCode { get; set; }
    }
}
