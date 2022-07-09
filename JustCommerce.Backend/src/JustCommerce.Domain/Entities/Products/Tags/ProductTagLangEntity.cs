namespace JustCommerce.Domain.Entities.Products.Tags
{
    public sealed class ProductTagLangEntity
    {
        public string Name { get; set; } = String.Empty;
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
