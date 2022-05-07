using JustCommerce.Application.Common.DTOs.Offer;
using JustCommerce.Domain.Entities.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Offer
{
    public class OfferItemDtoFactory
    {
        public static OfferItemDTO CreateFromEntity(OfferItemEntity offer)
        {
            return new OfferItemDTO
            {
                OfferId = offer.OfferId,
                ProductSellableId = offer.ProductSellableId,
                GrossPrice = offer.GrossPrice,
                NettoPrice = offer.NettoPrice,
                ProducentPrice = offer.ProducentPrice,
                Quantity = offer.Quantity,
                Tax = offer.Tax,
            };
        }
    }
}
