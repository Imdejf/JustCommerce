using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Manufacturer
{
    public sealed class ManufacturerLangEntity
    {
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

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
    }
}
