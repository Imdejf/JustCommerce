using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.CheckoutAttributes
{
    public interface ICheckoutAttrbiuteRepository : IBaseRepository<CheckoutAttributeEntity>
    {
        Task<CheckoutAttributeEntity?> GetFullyById(Guid checkoutAttributeId, CancellationToken cancellationToken = default);
        Task<bool> CheckoutAttributeValueHasValueAsync(Guid checkoutAttributeId, Guid checkoutAttributeValueId, CancellationToken cancellationToken = default);
        void RemoveCheckoutAttributeValueById(Guid checkoutAttributeValueId);
    }
}
