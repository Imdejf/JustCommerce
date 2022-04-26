using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Language
{
    public sealed class LanguageEntity : AuditableEntity
    {
        public string IsoCode { get; set; }
        public string Name { get; set; }
    }
}
