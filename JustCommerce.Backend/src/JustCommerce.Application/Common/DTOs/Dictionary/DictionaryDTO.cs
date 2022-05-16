namespace JustCommerce.Application.Common.DTOs.Dictionary
{
    public class DictionaryDTO
    {
        public Guid DictionaryTypeId { get; set; }
        public string Name { get; set; }
        public string Dictionary { get; set; }
        public ICollection<DictionaryLangDTO> DictionaryLang { get; set; }
    }
}
