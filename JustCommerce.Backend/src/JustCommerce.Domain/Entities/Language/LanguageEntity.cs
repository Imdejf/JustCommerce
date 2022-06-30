using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Language
{
    public sealed class LanguageEntity : AuditableEntity
    {
        public bool IsActive { get; set; }
        public string IsoCode { get; set; }
        public string NameOrginal { get; set; }
        public string NameInternational { get; set; }
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public LanguageEntity() { }

        public LanguageEntity(string id, string nameOrginal, string isoCode, string nameInternational, bool isActive, string shopId)
        {
            Id = Guid.Parse(id);
            NameOrginal = nameOrginal;
            IsoCode = isoCode;
            NameInternational = nameInternational;
            IsActive = isActive;
            ShopId = Guid.Parse(shopId);
        }
    }
}
