using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Application.Features.AdministrationFeatures.Category.Command;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Features.AdministrationFeatures.CategoryTests
{
    public class CreateCategoryTests
    {
        private readonly Helpers _helpers;

        public CreateCategoryTests()
        {
            _helpers = new Helpers(new DependencyContainer());
        }

        [Test]
        public async Task After_Created_Category_Exist_In_Database()
        {
            var newCategory = Helper.CategoryHelper.CreateCategory();
            var category = await _helpers.Send(new CreateCategory.Command(newCategory.Slug, newCategory.IconPath, newCategory.OrderValue,null,newCategory.CategoryLangs.ToList()));

            Assert.NotNull(await _helpers._unitOfWorkAdministration.Category.GetByIdAsync(category.CategoryId));
        }

        [Test]
        public async Task After_Created_Category_Exist_In_Database_With_Data()
        {
            var newCategory = Helper.CategoryHelper.CreateCategory();
            var category = await _helpers.Send(new CreateCategory.Command(newCategory.Slug, newCategory.IconPath, newCategory.OrderValue, null, newCategory.CategoryLangs.ToList()));

            var categoryDetail = await _helpers._unitOfWorkAdministration.Category.GetCategoryById(category.CategoryId);

            Assert.AreEqual(newCategory.Slug, categoryDetail.Slug);
            Assert.AreEqual(newCategory.OrderValue, categoryDetail.OrderValue);
            Assert.AreEqual(newCategory.IconPath, categoryDetail.IconPath);
            Assert.AreEqual(1, categoryDetail.CategoryLang.Count);
        }

        [Test]
        public async Task Created_Relation_Category_With_Parent_Category()
        {
            var newCategory = Helper.CategoryHelper.CreateCategory();
            var parentCategory = await _helpers.Send(new CreateCategory.Command(newCategory.Slug, newCategory.IconPath, newCategory.OrderValue, null, newCategory.CategoryLangs.ToList()));
            var category = await _helpers.Send(new CreateCategory.Command("NewSlug", newCategory.IconPath, newCategory.OrderValue, parentCategory.CategoryId, newCategory.CategoryLangs.ToList()));

            var categoryDetail = await _helpers._unitOfWorkAdministration.Category.GetByIdAsync(category.CategoryId);

            Assert.AreEqual(parentCategory.CategoryId, categoryDetail.ParentId);
            Assert.AreEqual(1, categoryDetail.ChildCategory.Count);
        }
    }
}
