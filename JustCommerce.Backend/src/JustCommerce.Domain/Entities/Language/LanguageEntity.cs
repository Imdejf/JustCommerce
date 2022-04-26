using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Language
{
    public sealed class LanguageEntity : AuditableEntity
    {
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public LanguageEntity() { }

        public LanguageEntity(string id, string name, string isoCode)
        {
            Id = Guid.Parse(id);
            Name = name;
            IsoCode = isoCode;
            CreatedDate = DateTime.Now;
        }
    }
}
