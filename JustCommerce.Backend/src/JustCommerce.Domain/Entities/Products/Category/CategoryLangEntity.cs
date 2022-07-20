using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Products.Category
{
    public sealed class CategoryLangEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

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

        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
    }
}
