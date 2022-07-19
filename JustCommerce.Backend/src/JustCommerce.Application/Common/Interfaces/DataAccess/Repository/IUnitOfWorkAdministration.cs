﻿using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.CheckoutAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Attributes.SpecificationAttributes;

namespace JustCommerce.Application.Common.DataAccess.Repository
{
    public interface IUnitOfWorkAdministration
    {
        IProductAttributeRepository ProductAttribute { get; }
        ISpecificationAttributeGroupRepository SpecificationAttributeGroup { get; }
        ISpecificationAttributeRepository SpecificationAttribute { get; }
        ISpecificationAttributeOptionRepository SpecificationAttributeOption { get; }
        ICheckoutAttrbiuteRepository CheckoutAttrbiute { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
