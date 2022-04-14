using JustCommerce.Application.Features.AdministrationFeatures.ProductTypeProperty.Command;
using JustCommerce.Domain.Entities.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories
{
    public static class ProductTypePropertyFactory
    {
        public static ProductTypePropertyEntity CreateFromProductTypePropertyCommand(CreateProductTypeProperty.Command command)
        {
            return new ProductTypePropertyEntity
            {
                ProductTypeId = command.ProductTypeId,
                OrderValue = command.OrderValue,
                PropertyType = command.PropertyType,
            };
        }
    }
}
