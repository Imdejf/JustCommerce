using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;

namespace JustCommerce.Domain.Entities.Dictionary
{
    public sealed class DictionaryEntity : AuditableEntity
    {
        public Guid DictionaryTypeId { get; set; }
        public DictionaryTypeEntity DictionaryType { get; set; }
        public string Name { get; set; }
        public string Dictionary { get; set; }
        ICollection<DictionaryLangEntity> DictionaryLang { get; set; }
    }
}
