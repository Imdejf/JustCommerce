using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Domain.Entities.Product;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product
{
    public static class ProductSellableEntityFactory
    {
        public static ProductSellableEntity CreateFromDto(ProductSellableDTO productSellableDTO)
        {
            return new ProductSellableEntity
            {
                Currency = productSellableDTO.Currency,
                EanCode = productSellableDTO.EanCode,
                GrossPrice = productSellableDTO.GrossPrice,
                NettoPrice = productSellableDTO.NettoPrice,
                IconPath = productSellableDTO.IconPath,
                OldPrice = productSellableDTO.OldPrice,
                ProductColor = productSellableDTO.ProductColor,
                ProductId = productSellableDTO.ProductId,
                Weight = productSellableDTO.Weight,
                Tax = productSellableDTO.Tax,
                ProductNumber = productSellableDTO.ProductNumber,
                ProducentPrice = productSellableDTO.ProducentPrice,
            };
        }

        public static ProductSellableEntity CreateFromData(Guid productId, Currency currency,string productNumber, string eanCode, decimal nettoPrice,decimal tax, decimal grossPrice, decimal oldPrice,
                                                           decimal producentPrice,ProductColor productColor, string tags, decimal weight, string iconPath)
        {
            return new ProductSellableEntity
            {
                Currency = currency,
                EanCode = eanCode,
                GrossPrice = grossPrice,
                NettoPrice = nettoPrice,
                IconPath = iconPath,
                OldPrice = oldPrice,
                ProductColor = productColor,
                ProductId = productId,
                Weight = weight,
                Tax = tax,
                ProductNumber = productNumber,
                ProducentPrice = producentPrice,
            };
        }
    }
}
