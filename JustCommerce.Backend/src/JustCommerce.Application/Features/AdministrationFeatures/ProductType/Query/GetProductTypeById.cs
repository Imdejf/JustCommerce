using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.ProductType;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query
{
    public static class GetProductTypeById
    {
        public sealed record Query(Guid ProductTypeId) : IRequestWrapper<ProductTypeEntity>;

        public sealed class Handler : IRequestHandlerWrapper<Query, ProductTypeEntity>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ProductTypeEntity> Handle(Query request, CancellationToken cancellationToken)
            {
                var productType = await _unitOfWorkAdministration.ProductType.GetByIdAsync(request.ProductTypeId, cancellationToken);

                if (productType is null)
                {
                    throw new EntityNotFoundException($"Update ProductType Id:{request.ProductTypeId}");
                }

                return productType;
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
