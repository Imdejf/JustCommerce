//using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command;
//using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query;
//using JustCommerce.Shared.Exceptions;
//using NUnit.Framework;
//using System;
//using System.Threading.Tasks;

//namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTypeTests
//{
//    public class GetProductTypeByIdTests
//    {
//        private readonly Helpers _helpers;

//        public GetProductTypeByIdTests()
//        {
//            _helpers = new Helpers(new DependencyContainer());
//        }

//        [Test]
//        public async Task Return_Product_Type()
//        {
//            var newProductType = await _helpers.Send(new CreateProductType.Command("Test"));

//            var productType = await _helpers.Send(new GetProductTypeById.Query(newProductType.Id));

//            Assert.NotNull(productType);
//        }

//        [Test]
//        public async Task Throws_Exception_If_Guid_Not_Exist()
//        {
//            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _helpers.Send(new GetProductTypeById.Query(Guid.NewGuid())));
//        }
//    }
//}
