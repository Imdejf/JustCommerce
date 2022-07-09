using JustCommerce.Application.Common.DTOs.Category;
using System;
using System.Collections.Generic;

namespace Application.IntegrationTests.Features.AdministrationFeatures.CategoryTests.Helper
{
    public static class CategoryHelper
    {
        public static CategoryDTO CreateCategory()
        {
            var category = new CategoryDTO()
            {
                IconPath = "Test",
                OrderValue = 2,
                Slug = "Test",
                CategoryLangs = new List<CategoryLangsDTO>()
                {
                    new CategoryLangsDTO
                    {
                        Description = "Test",
                        Content = "Test",
                        LanguageId = Guid.NewGuid(),
                        Name = "Test",
                        Keywords = "Test"
                    }
                }
            };
            return category;
        }
    }
}
