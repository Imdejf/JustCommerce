using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Domain.Entities.Common
{
    public class ProductCategoryEntity
    {
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public Guid ProductId { get; set; }
    }
}
