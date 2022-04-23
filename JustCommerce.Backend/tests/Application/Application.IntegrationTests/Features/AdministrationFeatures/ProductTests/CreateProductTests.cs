using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTests
{
    public class CreateProductTests
    {
        private readonly Helpers _helpers;

        public CreateProductTests()
        {
            _helpers = new Helpers(new DependencyContainer());
        }

        [Test]
        public async Task After_Created_Product_Exist_In_Database()
        {

        }
    }
}
