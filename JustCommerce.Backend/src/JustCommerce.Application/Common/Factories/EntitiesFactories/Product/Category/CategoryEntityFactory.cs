using JustCommerce.Application.Features.AdministrationFeatures.Product.Category.Command;
using JustCommerce.Domain.Entities.Products.Category;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Category
{
    public static class CategoryEntityFactory
    {
        public static CategoryEntity CreateFromCommand(CreateCategory.Command command)
        {
            return new CategoryEntity
            {
                ParentCategoryId = command.ParentCategoryId,
                StoreId = command.StoreId,
                IncludeInTopMenu = command.IncludeInTopMenu,
                Deleted = command.Deleted,
                DisplayOrder = command.DisplayOrder,
                PriceFrom = command.PriceFrom,
                ManuallyPriceRange = command.ManuallyPriceRange,
                Published = command.Published,
                PriceRangeFiltering = command.PriceRangeFiltering,
                ShowOnHomepage = command.ShowOnHomepage,
                SubjectToAcl = command.SubjectToAcl,
                PriceTo = command.PriceFrom,
                CategoryLang = command.CategoryLang.Select(c => CategoryLangEntityFactory.CreateFromDto(c)).ToList()
            };
        }
    }
}
