using JustCommerce.Application.Common.DTOs.Product.Category;
using JustCommerce.Domain.Entities.Products.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Category
{
    public static class CategoryLangEntityFactory
    {
        public static CategoryLangEntity CreateFromDto(CategoryLangDTO dto)
        {
            return new CategoryLangEntity
            {
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                MetaDescription = dto.MetaDescription,
                MetaKeywords = dto.MetaKeywords,
                MetaTitle = dto.MetaTitle,
                Name = dto.Name,
                LanguageId = dto.LanguageId,
            };
        }
    }
}
