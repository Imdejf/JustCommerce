namespace JustCommerce.Application.Common.DTOs.Category
{
    public class SubCategoryDTO
    {
        public Guid CategoryId { get; set; }
        public string Slug { get; set; }
        public int OrderValue { get; set; }
        public string IconPath { get; set; }
        public ICollection<SubCategoryLangsDTO>? CategoryLangs { get; set; }
    }
}
