namespace JustCommerce.Application.Common.DTOs.Company
{
    public class StoreDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool Active { get; set; }
        public string FullName { get; set; } = String.Empty;
        public string AddressLine { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string Zip { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    }
}
