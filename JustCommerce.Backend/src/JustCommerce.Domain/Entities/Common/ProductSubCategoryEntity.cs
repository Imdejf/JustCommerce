using JustCommerce.Domain.Entities.Category;
using JustCommerce.Domain.Entities.Product;

namespace JustCommerce.Domain.Entities.Common
{
    public class ProductSubCategoryEntity
    {
        public Guid SubCategoryId { get; set; }
        public SubCategoryEntity SubCategory { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
