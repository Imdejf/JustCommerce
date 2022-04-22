using JustCommerce.Application.Features.AdministrationFeatures.Category.Command;
using JustCommerce.Shared.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Features.AdministrationFeatures.CategoryTests
{
    public class DeleteCategoryTests
    {
        private readonly Helpers _helpers;

        public DeleteCategoryTests()
        {
            _helpers = new Helpers(new DependencyContainer());
        }

        [Test]
        public async Task After_Removed_Category_Not_Exist_in_Database()
        {
            var newCategory = Helper.CategoryHelper.CreateCategory();
            var category = await _helpers.Send(new CreateCategory.Command(newCategory.Slug, newCategory.IconPath, newCategory.OrderValue, null, newCategory.CategoryLangs.ToList()));
            Assert.True(await _helpers._unitOfWorkAdministration.Category.ExistsAsync(category.CategoryId));

            await _helpers.Send(new RemoveCategory.Command(category.CategoryId));
            Assert.True(!await _helpers._unitOfWorkAdministration.Category.ExistsAsync(category.CategoryId));
        }

        [Test]
        public async Task Throws_Exception_If_Guid_Not_Exist()
        {
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _helpers.Send(new RemoveCategory.Command(Guid.NewGuid())));
        }
    }
}
