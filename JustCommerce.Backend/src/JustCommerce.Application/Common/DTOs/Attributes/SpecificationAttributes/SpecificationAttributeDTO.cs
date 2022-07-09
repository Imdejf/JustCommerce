namespace JustCommerce.Application.Common.DTOs.Attributes.SpecificationAttributes
{
    public sealed class SpecificationAttributeDTO
    {
        public Guid Id { get; set; }
        public Guid SpecificationAttributeGroupId { get; set; }
        public string Name { get; set; } = String.Empty;
        public int DisplayOrder { get; set; }

        public ICollection<SpecificationAttributeOptionEntity> SpecificationAttributeOption { get; set; }
    }
}
