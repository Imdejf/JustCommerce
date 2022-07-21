namespace JustCommerce.Application.Common.DTOs.Customer.Vendor
{
    public sealed class VendorDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Guid AddressId { get; set; }
        public string AdminComment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public bool PriceRangeFiltering { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public bool ManuallyPriceRange { get; set; }
        public ICollection<VendorLangDTO> VendorLang { get; set; }
    }
}
