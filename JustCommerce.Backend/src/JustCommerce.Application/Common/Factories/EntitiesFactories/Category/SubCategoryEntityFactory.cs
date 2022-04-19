using JustCommerce.Application.Features.AdministrationFeatures.SubCategory.Command;
using JustCommerce.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Category
{
    public static class SubCategoryEntityFactory
    {
        public static SubCategoryEntity CreateFromCategoryCommand(CreateSubCategory.Command command)
        {
            return new SubCategoryEntity
            {
                CategoryId = command.CategoryId,
                Slug = command.Slug,
                OrderValue = command.OrderValue,
                IconPath = command.IconPath,
            };
        }
    }
}
