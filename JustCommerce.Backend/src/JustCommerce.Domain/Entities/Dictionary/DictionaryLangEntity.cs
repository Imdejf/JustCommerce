using JustCommerce.Domain.Entities.Language;

namespace JustCommerce.Domain.Entities.Dictionary
{
    public sealed class DictionaryLangEntity
    {
        public Guid DictionaryId { get; set; }
        public DictionaryEntity Dictionary { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Text { get; set; }
    }
}
