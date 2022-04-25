namespace JustCommerce.Application.Common.DTOs.Product
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public bool Top { get; set; }
        public bool AvailabilityType { get; set; }
        public bool Active { get; set; }
        public bool Newsletter { get; set; }

        public ICollection<ProductLangDTO>? ProductLang { get; set; }
    }
}
