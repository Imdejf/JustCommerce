namespace JustCommerce.Application.Common.DTOs.Product.Tag
{
    public sealed class ProductTagLangDTO
    {
        public Guid ProductTagId { get; set; }
        public Guid LanguageId { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
