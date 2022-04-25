namespace JustCommerce.Domain.Entities.ProductType
{
    public class ProductTypePropertyLangEntity
    {
        public Guid? ProductTypePropertyId { get; set; }
        public ProductTypePropertyEntity? ProductTypeProperty { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? DefualtValue { get; set; }
        public string? IsoCode { get; set; }
    }
}
