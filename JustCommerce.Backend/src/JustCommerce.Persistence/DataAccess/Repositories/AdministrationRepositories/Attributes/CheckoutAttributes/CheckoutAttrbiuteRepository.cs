using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.CheckoutAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Attributes.CheckoutAttributes
{
    internal sealed class CheckoutAttrbiuteRepository : BaseRepository<CheckoutAttributeEntity>, ICheckoutAttrbiuteRepository
    {
        private DbSet<CheckoutAttributeValueEntity> _CheckoutAttributeValue;
        public CheckoutAttrbiuteRepository(DbSet<CheckoutAttributeEntity> entity, DbSet<CheckoutAttributeValueEntity> checkoutAttributeValue) : base(entity)
        {
            _CheckoutAttributeValue = checkoutAttributeValue;
        }

        public Task<CheckoutAttributeEntity?> GetFullyById(Guid checkoutAttributeId, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.Id == checkoutAttributeId).Include(c => c.CheckoutAttributeValue).ThenInclude(c => c.CheckoutAttributeValueLang).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<bool> CheckoutAttributeValueHasValueAsync(Guid checkoutAttributeId, Guid checkoutAttributeValueId, CancellationToken cancellationToken = default)
        {
            return _CheckoutAttributeValue.Where(c => c.CheckoutAttributeId == checkoutAttributeId && c.Id == checkoutAttributeValueId).AnyAsync(cancellationToken);
        }

        public void RemoveCheckoutAttributeValueById(Guid checkoutAttributeValueId)
        {
            var attachedEntity = _CheckoutAttributeValue.Attach(new CheckoutAttributeValueEntity { Id = checkoutAttributeValueId });
            attachedEntity.State = EntityState.Deleted;
        }
    }
}
