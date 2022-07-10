namespace JustCommerce.Application.Common.DTOs.Attributes.SpecificationAttributes
{
    public class SpecificationGroupDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int DisplayOrder { get; set; }
        public Guid StoreId { get; set; }
        public List<SpecificationAttributeDTO> SpecificationAttribute { get; set; }
    }
}
