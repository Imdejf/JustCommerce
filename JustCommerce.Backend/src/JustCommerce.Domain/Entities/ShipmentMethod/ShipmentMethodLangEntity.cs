using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.ShipmentMethod
{
    public sealed class ShipmentMethodLangEntity
    {
        public Guid ShipmentMethodId { get; set; }
        public ShipmentMethodEntity ShipmentMethod { get; set; }
        public Guid LangaugeId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Name { get; set; }
    }
}
