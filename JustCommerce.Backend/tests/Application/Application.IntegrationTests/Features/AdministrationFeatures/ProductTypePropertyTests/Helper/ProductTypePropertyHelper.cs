using JustCommerce.Application.Common.DTOs;
using System.Collections.Generic;

namespace Application.IntegrationTests.Features.AdministrationFeatures.ProductTypePropertyTests.Object
{
    public static class ProductTypePropertyHelper
    {
        public static List<ProductTypePropertyDTO> productTypePropertyDto()
        {
            List<ProductTypePropertyDTO> producTypePropertyList = new List<ProductTypePropertyDTO>();

            var productTypeProeprtyFirst = new ProductTypePropertyDTO
            {
                OrderValue = 1,
                PropertyType = JustCommerce.Domain.Enums.PropertyType.Int,
                ProductTypePropertyLangs = new List<ProductTypePropertyLangDTO>
                {
                    new ProductTypePropertyLangDTO
                    {
                        DefualtValue = "Test",
                        IsoCode = "PL-pl",
                        Name = "Test",
                        Value = "Test"
                    }
                }
            };
            var productTypeProeprtySecond = new ProductTypePropertyDTO
            {
                OrderValue = 1,
                PropertyType = JustCommerce.Domain.Enums.PropertyType.Int,
                ProductTypePropertyLangs = new List<ProductTypePropertyLangDTO>
                {
                    new ProductTypePropertyLangDTO
                    {
                        DefualtValue = "Test",
                        IsoCode = "PL-pl",
                        Name = "Test",
                        Value = "Test"
                    }
                }
            };

            producTypePropertyList.Add(productTypeProeprtyFirst);
            producTypePropertyList.Add(productTypeProeprtySecond);

            return producTypePropertyList;
        }
    }
}
