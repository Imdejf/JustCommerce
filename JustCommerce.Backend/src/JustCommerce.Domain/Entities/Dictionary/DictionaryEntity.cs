using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Dictionary
{
    public sealed class DictionaryEntity : AuditableEntity
    {
        public Guid DictionaryTypeId { get; set; }
        public DictionaryTypeEntity DictionaryType { get; set; }
        public string Name { get; set; }
        public string Dictionary { get; set; }
        public ICollection<DictionaryLangEntity> DictionaryLang { get; set; }
    }
}
