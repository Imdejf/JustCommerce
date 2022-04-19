using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Category
{
    public static class SubCategoryDtoFactory
    {
        public static SubCategoryDTO CreateFromEntity(SubCategoryEntity subCategory)
        {
            return new SubCategoryDTO
            {
                CategoryId = subCategory.Id,
                IconPath = subCategory.IconPath,
                OrderValue = subCategory.OrderValue,
                Slug = subCategory.Slug,
                CategoryLangs = subCategory.SubCategoryLang?.Select(c => SubCategoryLangsDtoFactory.CreateFromEntity(c)).ToArray()
            };
        }
    }
}
