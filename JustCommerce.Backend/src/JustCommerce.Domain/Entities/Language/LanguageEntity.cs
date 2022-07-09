using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Language
{
    public sealed class LanguageEntity : Entity
    {
        public bool IsActive { get; set; }
        public string IsoCode { get; set; } = String.Empty;
        public string NameOrginal { get; set; } = String.Empty;
        public string NameInternational { get; set; } = String.Empty;
        public bool DefaultLanguage { get; set; }
        public Guid ShopId { get; set; }
        public StoreEntity Shop { get; set; } = new StoreEntity();
    }
}
