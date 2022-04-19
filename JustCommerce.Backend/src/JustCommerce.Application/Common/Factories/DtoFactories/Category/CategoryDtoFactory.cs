using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Application.Common.Factories.DtoFactories
{
    public static class CategoryDtoFactory
    {
        public static CategoryDTO CreateFromEntity(CategoryEntity category)
        {
            return new CategoryDTO
            {
                CategoryId = category.Id,
                IconPath = category.IconPath,
                OrderValue = category.OrderValue,
                Slug = category.Slug,
                CategoryLangs = category.CategoryLang?.Select(c => CategoryLangsDtoFactory.CreateFromEntity(c)).ToArray()
            };
        }
    }
}
