namespace JustCommerce.Application.Common.DTOs
{
    public class ProductTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductTypePropertyDTO>? ProductTypeProperty { get; set; }
    }
}
