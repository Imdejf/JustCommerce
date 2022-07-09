namespace JustCommerce.Application.Common.DTOs.Attributes.SpecificationAttributes
{
    public class SpecificationAttributeGroupDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int DisplayOrder { get; set; }
    }
}
