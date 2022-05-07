using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Offer;
using JustCommerce.Domain.Enums;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Offer
{
    public interface IOfferRepository : IBaseRepository<OfferEntity>
    {
        void SetStatusType(Guid offerId, OfferStatusType offerStatusType);
        Task<OfferEntity?> GetFullyOffer(Guid offerId, CancellationToken cancellationToken);
    }
}
