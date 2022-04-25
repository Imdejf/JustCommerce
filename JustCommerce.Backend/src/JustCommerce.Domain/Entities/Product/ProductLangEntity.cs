using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Product
{
    public class ProductLangEntity : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? Synonyms { get; set; }
        public string? Tags { get; set; }
        public string? Keywords { get; set; }
        public string? ImageDescription { get; set; }
        public string? ProductPropertyJson { get; set; }
        public string? IsoCode { get; set; }
    }
}