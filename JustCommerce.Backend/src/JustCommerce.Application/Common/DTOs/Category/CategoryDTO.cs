using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Application.Common.DTOs.Category
{
    public class CategoryDTO
    {
        public Guid CategoryId { get; set; }
        public string Slug { get; set; }
        public int OrderValue { get; set; }
        public string IconPath { get; set; }
        public Guid? ParentId { get; set; }
        public ICollection<CategoryLangsDTO>? CategoryLangs { get; set; }
        public ICollection<CategoryDTO>? ChildCategory { get; set; }
    }
}
