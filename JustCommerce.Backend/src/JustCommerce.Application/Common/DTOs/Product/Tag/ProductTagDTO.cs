using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Application.Common.DTOs.Product.Tag
{
    public sealed class ProductTagDTO
    {
        public Guid? Id { get; set; }
        public Guid? StoreId { get; set; }
        public StoreEntity Store { get; set; }
        public ICollection<ProductTagLangDTO> ProductTagLang { get; set; }
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
