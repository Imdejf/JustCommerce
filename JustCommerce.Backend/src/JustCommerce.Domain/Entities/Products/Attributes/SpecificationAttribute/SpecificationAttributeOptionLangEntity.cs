using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute
{
    public class SpecificationAttributeOptionLangEntity
    {
        public Guid SpecificationAttributeOptionId { get; set; }
        public SpecificationAttributeOptionEntity SpecificationAttributeOption { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
