namespace JustCommerce.Application.Common.DTOs.ShipmentMethod
{
    public class ShipmentMethodDTO
    {
        public int OrderValue { get; set; }
        public ICollection<ShipmentMethodLangDTO> ShipmentMethodLang { get; set; }
    }
}
