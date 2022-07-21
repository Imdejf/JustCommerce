using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Manufacturer;
using JustCommerce.Application.Common.Factories.DtoFactories.Product.Manufacturer;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Manufacturer;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Manufacturers.Command
{
    public static class CreateManufacturer
    {
        public sealed record Command() : IRequest<ManufacturerDTO>
        {
            public Guid StoreId { get; set; }
            public string Name { get; set; }
            public bool SubjectToAcl { get; set; }
            public bool Published { get; set; }
            public bool Deleted { get; set; }
            public int DisplayOrder { get; set; }
            public DateTime CreatedOnUtc { get; set; }
            public DateTime UpdatedOnUtc { get; set; }
            public bool PriceRangeFiltering { get; set; }
            public decimal PriceFrom { get; set; }
            public decimal PriceTo { get; set; }
            public bool ManuallyPriceRange { get; set; }
            public List<ManufacturerLangDTO> ManufacturerLang { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, ManufacturerDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ManufacturerDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }

                var newManufacturer = ManufacturerEntityFactory.CreateFromCommand(request);

                await _unitOfWorkAdministration.Manufacturer.AddAsync(newManufacturer, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = ManufacturerDtoFactory.CreateFromEntity(newManufacturer);

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
