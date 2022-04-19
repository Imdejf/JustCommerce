using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Category
{
    public static class SubCategoryLangsDtoFactory
    {
        public static SubCategoryLangsDTO CreateFromEntity(SubCategoryLangEntity entity)
        {
            return new SubCategoryLangsDTO
            {
                SubCategoryId = entity.SubCategoryId,
                Content = entity.Content,
                Description = entity.Description,
                IsoCode = entity.IsoCode,
                Keywords = entity.Keywords,
                Name = entity.Name,
            };
        }
    }
}
