namespace JustCommerce.Application.Common.DTOs
{
    public class CategoryDTO
    {
        public Guid CategoryId { get; set; }
        public string Slug { get; set; }
        public int OrderValue { get; set; }
        public string IconPath { get; set; }
        public ICollection<CategoryLangsDTO>? CategoryLangs { get; set; }
    }
}
