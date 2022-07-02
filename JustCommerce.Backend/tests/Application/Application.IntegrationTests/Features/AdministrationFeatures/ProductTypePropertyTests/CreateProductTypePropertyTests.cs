//using Application.IntegrationTests.Features.AdministrationFeatures.ProductTypePropertyTests.Object;
//using JustCommerce.Application.Common.DTOs;
//using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command;
//using JustCommerce.Application.Features.AdministrationFeatures.ProductTypeProperty.Command;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTypePropertyTests
//{
//    public class CreateProductTypePropertyTests
//    {
//        private readonly Helpers _helpers;

//        public CreateProductTypePropertyTests()
//        {
//            _helpers = new Helpers(new DependencyContainer());
//        }

//        [Test]
//        public async Task After_Created_Product_Type_Property_Exist_In_Database()
//        {
//            var productType = await _helpers.Send(new CreateProductType.Command("Test"));
//            Assert.True(await _helpers._unitOfWorkAdministration.ProductType.ExistsAsync(productType.Id));

//            await _helpers.Send(new CreateProductTypeProperty.Command(productType.Id, ProductTypePropertyHelper.productTypePropertyDto()));

//            var productTypeList = await _helpers._unitOfWorkAdministration.ProductTypeProperty.GetAllAsync();

//            Assert.AreEqual(2, productTypeList.Count);
//        }

//        [Test]
//        public async Task After_Created_Product_Type_Parse_With_Product_Type()
//        {
//            var productType = await _helpers.Send(new CreateProductType.Command("Test"));
//            Assert.True(await _helpers._unitOfWorkAdministration.ProductType.ExistsAsync(productType.Id));

//            await _helpers.Send(new CreateProductTypeProperty.Command(productType.Id, ProductTypePropertyHelper.productTypePropertyDto()));

//            var productTypeObject = await _helpers._unitOfWorkAdministration.ProductType.GetWithProductTypePropertyByIdAsync(productType.Id);

//            Assert.NotNull(productTypeObject);
//            Assert.AreEqual(2, productTypeObject?.ProductTypeProperty?.Count);
//        }
//    }
//}
