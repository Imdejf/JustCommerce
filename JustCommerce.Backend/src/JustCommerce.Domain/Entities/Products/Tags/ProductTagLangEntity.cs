using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Tags
{
    public sealed class ProductTagLangEntity
    {
        public Guid ProductTagId { get; set; }
        public ProductTagEntity ProductTag { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Name { get; set; } = String.Empty;
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
