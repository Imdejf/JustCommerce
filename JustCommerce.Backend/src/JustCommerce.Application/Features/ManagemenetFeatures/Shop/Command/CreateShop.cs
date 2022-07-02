using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Company;
using JustCommerce.Application.Common.Factories.DtoFactories.Company;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Company;
using JustCommerce.Application.Common.Interfaces;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Shop.Command
{
    public static class CreateShop
    {

        public sealed record Command(Guid Id, string Name, string State,  bool IsActive, string AddressLine, string City, string Country, string Email, string FullName, string Zip) : IRequestWrapper<ShopDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, ShopDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ShopDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var newShop = ShopEntityFactory.CreateFromShopCommand(request);
                await _unitOfWorkManagmenet.Shop.AddAsync(newShop, cancellationToken);

                return ShopDtoFactory.CreateFromEntity(newShop);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }

    }
}
