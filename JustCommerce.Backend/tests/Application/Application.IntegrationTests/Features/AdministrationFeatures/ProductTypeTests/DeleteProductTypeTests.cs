using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command;
using JustCommerce.Shared.Exceptions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTypeTests
{
    public class DeleteProductTypeTests
    {
        private readonly Helpers _helpers;

        public DeleteProductTypeTests()
        {
            _helpers = new Helpers(new DependencyContainer());
        }

        [Test]
        public async Task After_RemovedUser_User_Not_Exist_in_Database()
        {
            var productType = await _helpers.Send(new CreateProductType.Command("Test"));
            Assert.True(await _helpers._unitOfWorkAdministration.ProductType.ExistsAsync(productType.Id));

            await _helpers.Send(new RemoveProductType.Command(productType.Id));
            Assert.True(!await _helpers._unitOfWorkAdministration.ProductType.ExistsAsync(productType.Id));
        }

        [Test]
        public async Task Throws_Exception_If_Guid_Not_Exist()
        {
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _helpers.Send(new RemoveProductType.Command(Guid.NewGuid())));
        }
    }
}
