using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.EntitiesFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.ProductType;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductTypeProperty.Command
{
    public static class CreateProductTypeProperty
    {

        public sealed record Command(Guid ProductTypeId, List<ProductTypePropertyDTO> productTypePropertyDto) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var existProductType = await _unitOfWorkAdministration.ProductType.ExistsAsync(request.ProductTypeId, cancellationToken);

                if (!existProductType)
                {
                    throw new EntityNotFoundException($"ProductType with Id : {request.ProductTypeId} doesn`t exists");
                }

                List<ProductTypePropertyEntity> productTypePropertyList = new List<ProductTypePropertyEntity>();

                foreach (var productTypeProperty in request.productTypePropertyDto)
                {
                    var newProductTypeProperty = ProductTypePropertyFactory.CreateFromProductTypePropertyCommand(request.ProductTypeId, productTypeProperty);
                    
                    newProductTypeProperty.ProductTypePropertyLang = productTypeProperty.ProductTypePropertyLangs
                          .Select(c => ProductTypePropertyLangEntityFactory.CreateFromData(newProductTypeProperty.Id, c.Name, c.Value, c.DefualtValue, c.IsoCode))
                          .ToList();

                    productTypePropertyList.Add(newProductTypeProperty);
                };

                await _unitOfWorkAdministration.ProductTypeProperty.AddRangeProductTypePropertyAsync(productTypePropertyList, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ProductTypeId).NotEmpty();
            }
        }

    }
}
