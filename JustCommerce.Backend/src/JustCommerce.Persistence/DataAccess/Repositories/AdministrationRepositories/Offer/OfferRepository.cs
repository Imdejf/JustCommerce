using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Offer;
using JustCommerce.Domain.Entities.Offer;
using JustCommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Offer
{
    internal sealed class OfferRepository : BaseRepository<OfferEntity>, IOfferRepository
    {
        public OfferRepository(DbSet<OfferEntity> entity) : base(entity)
        {
        }

        public void SetStatusType(Guid offerId, OfferStatusType offerStatusType)
        {
            var attachedEntity = _entity.Attach(new OfferEntity { Id = offerId });
            attachedEntity.Entity.OfferStatusType = offerStatusType;
        }

        public Task<OfferEntity?> GetFullyOffer(Guid offerId, CancellationToken cancellationToken)
        {
            return _entity.Include(c => c.OfferItem)
                               .ThenInclude(c => c.ProductSellable)
                               .ThenInclude(c => c.Product)
                               .Include(c => c.ShipmentMethod)
                               .Where(c => c.Id == offerId)
                               .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
