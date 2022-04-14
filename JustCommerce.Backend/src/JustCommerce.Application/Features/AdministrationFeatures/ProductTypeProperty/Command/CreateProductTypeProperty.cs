using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Common.Factories.EntitiesFactories;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductTypeProperty.Command
{
    public static class CreateProductTypeProperty
    {

        public sealed record Command(Guid ProductTypeId,int OrderValue, PropertyType PropertyType, List<ProductTypePropertyLangDTO> ProductTypePropertyLangs) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var existProductType = await _unitOfWorkAdministration.ProductType.GetByIdAsync(request.ProductTypeId, cancellationToken);

                if(existProductType is null)
                {
                    throw new EntityNotFoundException($"ProductType with Id : {request.ProductTypeId} doesn`t exists");
                }

                var newProductTypeProperty = ProductTypePropertyFactory.CreateFromProductTypePropertyCommand(request);
                newProductTypeProperty.ProductTypePropertyLang = request.ProductTypePropertyLangs
                      .Select(c => ProductTypePropertyLangEntityFactory.CreateFromData(newProductTypeProperty.Id, c.Name, c.Value, c.DefualtValue, c.IsoCode))
                      .ToList();

                await _unitOfWorkAdministration.ProductTypeProperty.AddAsync(newProductTypeProperty);
                try
                {
                    await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }

                return Unit.Value;
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
