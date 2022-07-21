using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Attributes.CheckoutAttribute;
using JustCommerce.Application.Common.Factories.DtoFactories.Product.Attributes.Checkout;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Attributes.CheckoutAttributes;
using JustCommerce.Domain.Enums.Attribute;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Attributes.CheckoutAttributes.Command
{
    public sealed class CreateCheckoutAttribute
    {

        public sealed record Command() : IRequest<CheckoutAttributeDTO>
        {
            public Guid StoreId { get; set; }
            public string Name { get; set; } = String.Empty;
            public string TextPrompt { get; set; } = String.Empty;
            public bool IsRequired { get; set; }
            public bool ShippableProductRequired { get; set; }
            public bool IsTaxExempt { get; set; }
            public Guid? TaxCategoryId { get; set; }
            public AttributeControlType AttributeControlType { get; set; }
            public int DisplayOrder { get; set; }
            public Guid? ConditionAttributeId { get; set; }

            //validation fields
            public int? ValidationMinLength { get; set; }
            public int? ValidationMaxLength { get; set; }
            public string ValidationFileAllowedExtensions { get; set; } = String.Empty;
            public int? ValidationFileMaximumSize { get; set; }
            public string DefaultValue { get; set; } = String.Empty;
            public List<CheckoutAttributeValueDTO> CheckoutAttributeValue { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, CheckoutAttributeDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<CheckoutAttributeDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }

                var newCheckoutAttribute = CheckoutAttributeEntityFactory.CreateFromCommand(request);

                await _unitOfWorkAdministration.CheckoutAttrbiute.AddAsync(newCheckoutAttribute, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = CheckoutAttributeDtoFactory.CreateFromEntity(newCheckoutAttribute);

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
