using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Company
{
    public sealed class StoreEntity : Entity 
    {
        /// <summary>
        /// Gets or sets the store name
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the store URL
        /// </summary>
        public string Url { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether SSL is enabled
        /// </summary>
        public bool SslEnabled { get; set; }

        /// <summary>
        /// Gets or sets the comma separated list of possible HTTP_HOST values
        /// </summary>
        public string Hosts { get; set; } = String.Empty;


        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        public string CompanyName { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the company address
        /// </summary>
        public string CompanyAddress { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the store phone number
        /// </summary>
        public string CompanyPhoneNumber { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the company VAT (used in Europe Union countries)
        /// </summary>
        public string CompanyVat { get; set; } = String.Empty;

        public ICollection<LanguageEntity> Language { get; set; } = new HashSet<LanguageEntity>();
        public ICollection<UserStoreEntity> AllowedUser { get; set; } = new HashSet<UserStoreEntity>();
    }
}