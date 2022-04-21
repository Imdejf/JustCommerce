using JustCommerce.Application.Features.AdministrationFeatures.Category.Command;
using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories
{
    public static class CategoryEntityFactory
    {
        public static CategoryEntity CreateFromCategoryCommand(CreateCategory.Command command)
        {
            return new CategoryEntity
            {
                Slug = command.Slug,
                OrderValue = command.OrderValue,
                IconPath = command.IconPath,
                ParentId = command.ParentId,
            };
        }
    }
}
