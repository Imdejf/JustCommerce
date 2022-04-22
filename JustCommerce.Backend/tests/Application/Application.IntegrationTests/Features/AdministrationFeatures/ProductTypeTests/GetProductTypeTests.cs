using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command;
using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTypeTests
{
    public class GetProductTypeTests
    {
        private readonly Helpers _helpers;

        public GetProductTypeTests()
        {
            _helpers = new Helpers(new DependencyContainer());
        }

        [Test]
        public async Task Return_Product_Type()
        {
            await _helpers.Send(new CreateProductType.Command("Test"));
            await _helpers.Send(new CreateProductType.Command("Test1"));
            await _helpers.Send(new CreateProductType.Command("Test2"));

            var productTypeList = await _helpers.Send(new GetProductType.Query());

            Assert.AreEqual(3, productTypeList.Count);
        }
    }
}
