using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Vendor
{
    public sealed class VendorLangEntity
    {
        public Guid VendorId { get; set; }
        public VendorEntity Vendor { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

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
