using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.CheckoutAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.SpecificationAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Manufacturer;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Tags;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkAdministration
    {
        IProductAttributeRepository ProductAttribute { get; }
        ISpecificationAttributeGroupRepository SpecificationAttributeGroup { get; }
        ISpecificationAttributeRepository SpecificationAttribute { get; }
        ISpecificationAttributeOptionRepository SpecificationAttributeOption { get; }
        ICheckoutAttrbiuteRepository CheckoutAttrbiute { get; }
        IProductTagRepository ProductTag { get; }
        IManufacturerRepository Manufacturer { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
