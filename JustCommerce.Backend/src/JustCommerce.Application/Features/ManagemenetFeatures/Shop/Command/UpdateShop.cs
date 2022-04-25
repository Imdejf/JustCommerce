using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Company;
using JustCommerce.Application.Common.Factories.DtoFactories.Company;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Shop.Command
{
    public static class UpdateShop
    {

        public sealed record Command(Guid ShopId, string Name, string State, bool Active, string AddressLine, string City, string Country, string Email, string FullName, string Zip) : IRequestWrapper<ShopDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, ShopDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ShopDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var shop = await _unitOfWorkManagmenet.Shop.GetByIdAsync(request.ShopId, cancellationToken);

                if (shop is null)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                shop.Name = request.Name;
                shop.State = request.State;
                shop.Active = request.Active;
                shop.City = request.City;
                shop.Email = request.Email;
                shop.AddressLine = request.AddressLine;
                shop.Country = request.Country;
                shop.Zip = request.Zip;
                shop.FullName = request.FullName;

                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return ShopDtoFactory.CreateFromEntity(shop);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }

    }
}
