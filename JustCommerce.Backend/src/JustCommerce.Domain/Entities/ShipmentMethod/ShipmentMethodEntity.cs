using JustCommerce.Domain.Entities.Abstract;

namespace JustCommerce.Domain.Entities.ShipmentMethod
{
    public class ShipmentMethodEntity : AuditableEntity
    {
        public int OrderValue { get; set; }
        public ICollection<ShipmentMethodLangEntity> ShipmentMethodLang { get; set; }
    }
}
