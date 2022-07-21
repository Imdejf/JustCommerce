namespace JustCommerce.Domain.Entities.Products.Product
{
    public sealed class RelatedProductEntity
    {
        /// <summary>
        /// Gets or sets the first product identifier
        /// </summary>
        public Guid Product1Id { get; set; }
        public ProductEntity Product1 { get; set; }
        /// <summary>
        /// Gets or sets the second product identifier
        /// </summary>
        public Guid Product2Id { get; set; }
        public ProductEntity Product2 { get; set; }
        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
