using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.Dictionary
{
    public sealed class DictionaryEntity : AuditableEntity
    {
        public Guid Id { get; set; }
    }
}
