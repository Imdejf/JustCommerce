using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command
{
    public static class CreateProductAttribute
    {

        public sealed record Command() : IRequest<ProductAttributeEntity>
        {
            public Guid StoreId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<ProductAttributeLangDTO> ProductAttributeLang { get; set; }
            public List<PredefinedProductAttributeValueDTO> PredefinedProductAttributeValues { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, ProductAttributeEntity>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ProductAttributeEntity> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }

                var newAttribute = ProductAttributeEntityFactory.CreateFromProductCommand(request);

                await _unitOfWorkAdministration.ProductAttribute.AddAsync(newAttribute, cancellationToken);

                return newAttribute;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.StoreId).NotEqual(Guid.Empty);
                RuleFor(c => c.Name).NotEmpty();
            }
        }


    }
}
