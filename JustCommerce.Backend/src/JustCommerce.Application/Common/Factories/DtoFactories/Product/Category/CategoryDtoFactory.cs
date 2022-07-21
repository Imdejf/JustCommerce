using JustCommerce.Application.Common.DTOs.Product.Category;
using JustCommerce.Domain.Entities.Products.Category;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product.Category
{
    public static class CategoryDtoFactory
    {
        public static CategoryDTO CreateFromEntity(CategoryEntity entity)
        {
            return new CategoryDTO
            {
                StoreId = entity.StoreId,
                ShowOnHomepage = entity.ShowOnHomepage,
                SubjectToAcl = entity.SubjectToAcl,
                CreatedOnUtc = entity.CreatedOnUtc,
                Deleted = entity.Deleted,
                IncludeInTopMenu = entity.IncludeInTopMenu,
                ParentCategoryId = entity.ParentCategoryId,
                DisplayOrder = entity.DisplayOrder,
                ManuallyPriceRange = entity.ManuallyPriceRange,
                PriceFrom = entity.PriceFrom,
                PriceTo = entity.PriceFrom,
                UpdatedOnUtc = entity.CreatedOnUtc,
                Published = entity.Published,
                PriceRangeFiltering = entity.PriceRangeFiltering,
                CategoryLang = entity.CategoryLang.Select(c => CategoryLangDtoFactory.CreateFromEntity(c)).ToList()
            };
        }
    }
}
