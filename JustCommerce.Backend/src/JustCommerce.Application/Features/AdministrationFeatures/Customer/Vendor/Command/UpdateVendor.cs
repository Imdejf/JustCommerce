using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Customer.Vendor;
using JustCommerce.Application.Common.Factories.DtoFactories.Customer.Vendor;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Customer.Vendor;
using JustCommerce.Domain.Entities.Vendor;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Customer.Vendor.Command
{
    public static class UpdateVendor
    {

        public sealed record Command() : IRequest<VendorDTO>
        {
            public Guid VendorId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Description { get; set; }
            public Guid AddressId { get; set; }
            public string AdminComment { get; set; }
            public bool Active { get; set; }
            public bool Deleted { get; set; }
            public int DisplayOrder { get; set; }
            public bool PriceRangeFiltering { get; set; }
            public decimal PriceFrom { get; set; }
            public decimal PriceTo { get; set; }
            public bool ManuallyPriceRange { get; set; }
            public ICollection<VendorLangDTO> VendorLang { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, VendorDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<VendorDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentVendor = await _unitOfWorkAdministration.Vendor.GetByIdAsync(request.VendorId, cancellationToken);
                if (currentVendor is null)
                {
                    throw new EntityNotFoundException($"Vendor with id {request.VendorId} doesnt exist");
                }

                currentVendor.ManuallyPriceRange = request.ManuallyPriceRange;
                currentVendor.Active = request.Active;
                currentVendor.PriceFrom = request.PriceFrom;
                currentVendor.AddressId = request.AddressId;
                currentVendor.AdminComment = request.AdminComment;
                currentVendor.Deleted = request.Deleted;
                currentVendor.DisplayOrder = request.DisplayOrder;
                currentVendor.Description = request.Description;
                currentVendor.Email = request.Email;
                currentVendor.PriceFrom = request.PriceFrom;
                currentVendor.PriceTo = request.PriceTo;
                currentVendor.Name = request.Name;
                
                if(request.VendorLang is not null)
                {
                    foreach(var vendor in request.VendorLang)
                    {
                        var lang = currentVendor.VendorLang.Where(c => c.LanguageId == vendor.LanguageId).FirstOrDefault();

                        if(lang is null)
                        {
                            var entity = new VendorLangEntity
                            {
                                LanguageId = vendor.LanguageId,
                                MetaDescription = vendor.MetaDescription,
                                MetaKeywords = vendor.MetaKeywords,
                                MetaTitle = vendor.MetaTitle
                            };
                            currentVendor.VendorLang.Add(entity);
                        }
                        else
                        {
                            lang.MetaDescription = vendor.MetaDescription;
                            lang.MetaTitle = vendor.MetaTitle;
                            lang.MetaDescription = vendor.MetaDescription;
                            lang.MetaKeywords = vendor.MetaKeywords;
                        }
                    }

                    await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                    var dto = VendorDtoFactory.CreateFromEntity(currentVendor);

                    return dto;
                }
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
