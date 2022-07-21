using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Manufacturer;
using JustCommerce.Application.Common.Factories.DtoFactories.Product.Manufacturer;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Manufacturer;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Manufacturers.Command
{
    public static class UpdateManufacturer
    {

        public sealed record Command() : IRequest<ManufacturerDTO>
        {
            public Guid ManufacturerId { get; set; }
            public Guid StoreId { get; set; }
            public string Name { get; set; }
            public bool SubjectToAcl { get; set; }
            public bool Published { get; set; }
            public bool Deleted { get; set; }
            public int DisplayOrder { get; set; }
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
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ManufacturerDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentManufacturer = await _unitOfWorkAdministration.Manufacturer.GetFullyByIdAsync(request.ManufacturerId, cancellationToken);

                if(currentManufacturer is null)
                {
                    throw new EntityNotFoundException($"Manufacturer with id {request.ManufacturerId} doesnt exist");
                }

                currentManufacturer.Name = request.Name;
                currentManufacturer.SubjectToAcl = request.SubjectToAcl;
                currentManufacturer.PriceFrom = request.PriceFrom;
                currentManufacturer.ManuallyPriceRange = request.ManuallyPriceRange;
                currentManufacturer.PriceRangeFiltering = request.PriceRangeFiltering;
                currentManufacturer.UpdatedOnUtc = DateTime.Now;
                currentManufacturer.Deleted = request.Deleted;
                currentManufacturer.DisplayOrder = request.DisplayOrder;
                currentManufacturer.Published = request.Published;
                currentManufacturer.PriceTo = request.PriceFrom;
                
                foreach(var lang in request.ManufacturerLang)
                {
                    var manufacturerLang = currentManufacturer.ManufacturerLang.Where(c => c.LanguageId == lang.LanguageId && c.ManufacturerId == lang.ManufacturerId).FirstOrDefault();

                    if (manufacturerLang is null)
                    {
                        var entity = ManufacturerLangEntityFactory.CreateFromDto(lang);
                        currentManufacturer.ManufacturerLang.Add(entity);
                    }
                    else
                    {
                        manufacturerLang.MetaTitle = lang.MetaTitle;
                        manufacturerLang.MetaDescription = lang.MetaDescription;
                        manufacturerLang.Description = lang.Description;
                        manufacturerLang.MetaKeywords = lang.MetaKeywords;
                    }
                }

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = ManufacturerDtoFactory.CreateFromEntity(currentManufacturer);
                
                return dto;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ManufacturerId).NotEqual(Guid.Empty);
                RuleFor(c => c.StoreId).NotEqual(Guid.Empty);
            }
        }
    }
}
