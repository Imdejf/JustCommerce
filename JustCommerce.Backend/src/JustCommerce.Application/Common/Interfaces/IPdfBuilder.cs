using JustCommerce.Domain.Entities.Offer;

namespace JustCommerce.Application.Common.Interfaces
{
    public interface IPdfBuilder
    {
        Task<byte[]> OfferGenerate(OfferEntity offer);
    }
}
