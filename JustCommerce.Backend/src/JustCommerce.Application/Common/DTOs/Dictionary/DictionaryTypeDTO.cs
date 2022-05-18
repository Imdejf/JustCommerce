namespace JustCommerce.Application.Common.DTOs.Dictionary
{
    public class DictionaryTypeDTO
    {
        public Guid ShopId { get; set; }
        public string DictionaryType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DictionaryDTO> Dictionary { get; set; }
    }
}
