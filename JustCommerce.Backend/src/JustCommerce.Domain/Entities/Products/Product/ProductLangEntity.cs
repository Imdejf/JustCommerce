using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Product
{
    public sealed class ProductLangEntity
    {
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the short description
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the full description
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        public string MetaTitle { get; set; }

        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
    }
}
