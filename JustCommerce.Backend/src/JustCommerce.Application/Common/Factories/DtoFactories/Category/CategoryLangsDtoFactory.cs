using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Application.Common.Factories.DtoFactories
{
    public static class CategoryLangsDtoFactory
    {
        public static CategoryLangsDTO CreateFromEntity(CategoryLangEntity entity)
        {
            return new CategoryLangsDTO
            {
                CategoryId = entity.CategoryId,
                Content = entity.Content,
                Description = entity.Description,
                IsoCode = entity.IsoCode,
                Keywords = entity.Keywords,
                Name = entity.Name,
            };
        }
    }
}
