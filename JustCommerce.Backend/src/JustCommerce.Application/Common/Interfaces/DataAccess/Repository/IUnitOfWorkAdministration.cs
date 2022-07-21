using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Customer.Vendor;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.CheckoutAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.SpecificationAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Category;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Manufacturer;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Product;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Tags;

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
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IVendorRepository Vendor { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
