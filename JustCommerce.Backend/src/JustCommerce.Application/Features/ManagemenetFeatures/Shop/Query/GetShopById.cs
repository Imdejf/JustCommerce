using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Company;
using JustCommerce.Application.Common.Factories.DtoFactories.Company;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Shop.Query
{
    public static class GetShopById
    {

        public sealed record Query(Guid ShopId) : IRequestWrapper<ShopDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, ShopDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ShopDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var shop = await _unitOfWorkManagmenet.Shop.GetByIdAsync(request.ShopId, cancellationToken);

                if (shop is null)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                return ShopDtoFactory.CreateFromEntity(shop);
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }

    }
}
