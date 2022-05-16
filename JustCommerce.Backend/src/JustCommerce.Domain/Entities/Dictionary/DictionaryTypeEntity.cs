using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Enums.Dictionary;

namespace JustCommerce.Domain.Entities.Dictionary
{
    public sealed class DictionaryTypeEntity : AuditableEntity
    {
        public Guid ShopId { get; set; }
        public ShopEntity Shop { get; set; }
        public string DictionaryType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DictionaryEntity> Dictionary { get; set; }
    }
}
