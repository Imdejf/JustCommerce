using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.DTOs
{
    public class ProductTypePropertyDTO
    {
        public int OrderValue { get; set; }
        public PropertyType PropertyType { get; set; }
        public bool IsActive { get; set; }
        public bool EmptyValue { get; set; }
        public ICollection<ProductTypePropertyLangDTO>? ProductTypePropertyLangs { get; set; }
    }
}
