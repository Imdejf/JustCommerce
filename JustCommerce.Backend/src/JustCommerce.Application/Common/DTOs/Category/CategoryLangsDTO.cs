namespace JustCommerce.Application.Common.DTOs.Category
{
    public sealed class CategoryLangsDTO
    {
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public string IsoCode { get; set; }
    }
}
