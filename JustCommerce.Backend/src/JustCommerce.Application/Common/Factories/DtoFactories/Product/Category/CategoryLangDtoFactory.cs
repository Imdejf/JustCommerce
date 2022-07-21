using JustCommerce.Application.Common.DTOs.Product.Category;
using JustCommerce.Domain.Entities.Products.Category;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product.Category
{
    public static class CategoryLangDtoFactory
    {
        public static CategoryLangDTO CreateFromEntity(CategoryLangEntity entity)
        {
            return new CategoryLangDTO
            {
                LanguageId = entity.LanguageId,
                CategoryId = entity.CategoryId,
                Description = entity.Description,
                MetaDescription = entity.MetaDescription,
                MetaKeywords = entity.MetaKeywords,
                MetaTitle = entity.MetaTitle,
                Name = entity.Name,
            };
        }
    }
}
