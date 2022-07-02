//using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTypeTests
//{
//    public class CreateProductTypeTests
//    {
//        private readonly Helpers _helpers;

//        public CreateProductTypeTests()
//        {
//            _helpers = new Helpers(new DependencyContainer());
//        }
//        [Test]
//        public async Task After_Created_Product_Type_Exist_In_Database()
//        {
//            var productType = await _helpers.Send(new CreateProductType.Command("Test"));

//            Assert.True(await _helpers._unitOfWorkAdministration.ProductType.ExistsAsync(productType.Id));
//        }

//        [Test]
//        public async Task After_Created_Product_Type_Data_Exist_In_Database()
//        {
//            var productType = await _helpers.Send(new CreateProductType.Command("Test"));

//            var productTypeData = await _helpers._unitOfWorkAdministration.ProductType.GetByIdAsync(productType.Id);

//            Assert.AreEqual(productType.Name, productTypeData.Name);
//        }
//    }
//}
