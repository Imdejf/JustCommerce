using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Factories.DtoFactories.Product.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Attributes.ProductAttributes;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Attributes.ProductAttributes.Command
{
    public static class CreateProductAttribute
    {

        public sealed record Command() : IRequest<ProductAttributeDTO>
        {
            public Guid StoreId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<ProductAttributeLang> ProductAttributeLangs { get; set; }
            public record ProductAttributeLang
            {
                public Guid LanguageId { get; set; }
                public string Name { get; set; } = String.Empty;
            }

            public List<PredefinedProductAttributeValue> PredefinedProductAttributeValues { get; set; }
            public record PredefinedProductAttributeValue
            {
                public string Name { get; set; } = string.Empty;
                public decimal PriceAdjustment { get; set; }
                public bool PriceAdjustmentUsePercentage { get; set; }
                public decimal WeightAdjustment { get; set; }
                public decimal Cost { get; set; }
                public bool IsPreSelected { get; set; }
                public int DisplayOrder { get; set; }

                public List<PredefinedProductAttributeValueLang> PredefinedProductAttributeValueLangs { get; set; }
                public record PredefinedProductAttributeValueLang
                {
                    public Guid LanguageId { get; set; }
                    public string Name { get; set; } = String.Empty;
                }
            }

        }

        public sealed class Handler : IRequestHandler<Command, ProductAttributeDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ProductAttributeDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }

                var newAttribute = ProductAttributeEntityFactory.CreateFromProductCommand(request);

                await _unitOfWorkAdministration.ProductAttribute.AddAsync(newAttribute, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);
                var dto = ProductAttributeDtoFactory.CreateFromProductAttributeEntity(newAttribute);

                return dto;
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
