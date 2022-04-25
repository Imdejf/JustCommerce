using JustCommerce.Application.Common.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTests.Helper
{
    public static class ProductHelper
    {
        public static ProductDTO CreateProduct()
        {
            return new ProductDTO
            {
                Active = true,
                AvailabilityType = true,
                Newsletter = true,
                Slug = "Test",
                Top = true,
                ProductLang = new List<ProductLangDTO> {
                    new ProductLangDTO
                    {
                        Description = "test",
                        ImageDescription = "test",
                        MetaDescription = "test",
                        IsoCode = "PL-pl",
                        Keywords = "test",
                        MetaTitle = "test",
                        Name = "test",
                        Synonyms = "test",
                        Tags = "test"
                    }
                }
            };
        }
    }
}
