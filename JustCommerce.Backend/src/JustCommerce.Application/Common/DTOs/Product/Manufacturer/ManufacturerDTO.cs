namespace JustCommerce.Application.Common.DTOs.Product.Manufacturer
{
    public sealed class ManufacturerDTO
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public bool SubjectToAcl { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public bool PriceRangeFiltering { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public bool ManuallyPriceRange { get; set; }
        public ICollection<ManufacturerLangDTO> ManufacturerLang { get; set; }
    }
}
