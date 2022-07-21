using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Customer.Vendor;
using JustCommerce.Application.Common.Factories.DtoFactories.Customer.Vendor;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Customer.Vendor;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Customer.Vendor.Command
{
    public static class CreateVendor
    {

        public sealed record Command() : IRequest<VendorDTO>
        {
            public Guid StoreId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Description { get; set; }
            public Guid AddressId { get; set; }
            public string AdminComment { get; set; }
            public bool Active { get; set; }
            public bool Deleted { get; set; }
            public int DisplayOrder { get; set; }
            public bool AllowCustomersToSelectPageSize { get; set; }
            public bool PriceRangeFiltering { get; set; }
            public decimal PriceFrom { get; set; }
            public decimal PriceTo { get; set; }
            public bool ManuallyPriceRange { get; set; }
            public ICollection<VendorLangDTO> VendorLang { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, VendorDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<VendorDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }

                var newVendor = VendorEntityFactory.CreateFromCommand(request);

                await _unitOfWorkAdministration.Vendor.AddAsync(newVendor);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = VendorDtoFactory.CreateFromEntity(newVendor);

                return dto;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.StoreId).NotEqual(Guid.Empty);
            }
        }


    }
}
