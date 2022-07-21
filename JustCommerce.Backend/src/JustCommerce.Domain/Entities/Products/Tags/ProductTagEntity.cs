using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Tags
{
    public sealed class ProductTagEntity : Entity
    {
        public Guid StoreId { get; set; }
        public StoreEntity Store { get; set; }
        public string Name { get; set; } = String.Empty;
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public ICollection<ProductProductTagEntity> ProductProductTag { get; set; }
    }
}
