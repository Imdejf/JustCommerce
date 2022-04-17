using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.DtoFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.ProductType;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query
{
    public static class GetProductTypeById
    {
        public sealed record Query(Guid ProductTypeId) : IRequestWrapper<ProductTypeDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, ProductTypeDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ProductTypeDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var productType = await _unitOfWorkAdministration.ProductType.GetWithProductTypePropertyByIdAsync(request.ProductTypeId, cancellationToken);
                
                if (productType is null)
                {
                    throw new EntityNotFoundException($"Update ProductType Id:{request.ProductTypeId}");
                }

                var productTypeDto = ProductTypeDtoFactory.CreateFromEntity(productType);

                return productTypeDto;
            }
        }
        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ProductTypeId).NotEqual(Guid.Empty);
            }
        }
    }
}
