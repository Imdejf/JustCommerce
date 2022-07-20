using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Products.Tags
{
    public sealed class ProductTagEntity : Entity
    {
        public Guid StoreId { get; set; }
        public StoreEntity Store { get; set; }
        public List<ProductTagLangEntity> ProductTagLang { get; set; }
        public ICollection<ProductProductTagEntity> ProductProductTag { get; set; }
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
