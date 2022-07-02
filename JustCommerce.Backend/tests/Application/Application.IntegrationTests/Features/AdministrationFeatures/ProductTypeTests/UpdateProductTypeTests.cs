//using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command;
//using NUnit.Framework;
//using System.Threading.Tasks;


//namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTypeTests
//{
//    public class UpdateProductTypeTests
//    {
//        private readonly Helpers _helpers;

//        public UpdateProductTypeTests()
//        {
//            _helpers = new Helpers(new DependencyContainer());
//        }


//        [Test]
//        public async Task After_Update_Product_Type_Exist_In_Database()
//        {
//            //var productType = await _helpers.Send(new CreateProductType.Command("Test"));

//            Assert.True(await _helpers._unitOfWorkAdministration.ProductType.ExistsAsync(productType.Id));

//            var updateProductType = await _helpers.Send(new UpdateProductType.Command(productType.Id, "NewName"));

//            Assert.True(await _helpers._unitOfWorkAdministration.ProductType.ExistsAsync(productType.Id));
//        }

//        [Test]
//        public async Task After_Updated_Product_Type_Data_Updated_Correctly()
//        {

//           // var productType = await _helpers.Send(new CreateProductType.Command("Test"));

//            var updateProductType = await _helpers.Send(new UpdateProductType.Command(productType.Id, "NewName"));

//            var newProductType = await _helpers._unitOfWorkAdministration.ProductType.GetByIdAsync(productType.Id);
//            Assert.AreNotEqual(productType, newProductType.Name);
//        }
//    }
//}
