using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Domain.Entities.Category;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories
{
    public static class CategoryLangEntityFactory
    {
        public static CategoryLangEntity CreateFromDto(CategoryLangsDTO categoryLangsDTO)
        {
            return new CategoryLangEntity
            {
                Name = categoryLangsDTO.Name,
                Content = categoryLangsDTO.Content,
                Description = categoryLangsDTO.Description,
                IsoCode = categoryLangsDTO.IsoCode,
                Keywords = categoryLangsDTO.Keywords,
                CategoryId = categoryLangsDTO.CategoryId
            };
        }

        public static CategoryLangEntity CreateFromData(Guid categoryId, string name, string content, string description, string isoCode, string keywords)
        {
            return new CategoryLangEntity
            {
                CategoryId = categoryId,
                Name = name,
                Content = content,
                Description = description,
                IsoCode = isoCode,
                Keywords = keywords,
            };
        }
    }
}
