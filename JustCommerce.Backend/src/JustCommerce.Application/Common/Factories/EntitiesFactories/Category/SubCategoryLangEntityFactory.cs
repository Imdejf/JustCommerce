using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Category
{
    public static class SubCategoryLangEntityFactory
    {
        public static SubCategoryLangEntity CreateFromDto(SubCategoryLangsDTO categoryLangsDTO)
        {
            return new SubCategoryLangEntity
            {
                Name = categoryLangsDTO.Name,
                Content = categoryLangsDTO.Content,
                Description = categoryLangsDTO.Description,
                IsoCode = categoryLangsDTO.IsoCode,
                Keywords = categoryLangsDTO.Keywords,
                SubCategoryId = categoryLangsDTO.SubCategoryId
            };
        }

        public static SubCategoryLangEntity CreateFromData(Guid subCategoryId, string name, string content, string description, string isoCode, string keywords)
        {
            return new SubCategoryLangEntity
            {
                SubCategoryId = subCategoryId,
                Name = name,
                Content = content,
                Description = description,
                IsoCode = isoCode,
                Keywords = keywords,
            };
        }
    }
}
