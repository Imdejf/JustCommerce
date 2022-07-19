using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Attributes.CheckoutAttribute;
using JustCommerce.Application.Common.Factories.DtoFactories.Attributes.Checkout;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.CheckoutAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;
using JustCommerce.Domain.Enums.Attribute;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.CheckoutAttributes.Command
{
    public static class UpdateCheckoutAttribute
    {

        public sealed record Command() : IRequest<CheckoutAttributeDTO>
        {
            public Guid CheckoutAttributeId { get; set; }
            public string Name { get; set; } = String.Empty;
            public string TextPrompt { get; set; } = String.Empty;
            public bool IsRequired { get; set; }
            public bool ShippableProductRequired { get; set; }
            public bool IsTaxExempt { get; set; }
            public Guid TaxCategoryId { get; set; }
            public AttributeControlType AttributeControlType { get; set; }
            public int DisplayOrder { get; set; }
            public Guid ConditionAttributeId { get; set; }

            //validation fields
            public int? ValidationMinLength { get; set; }
            public int? ValidationMaxLength { get; set; }
            public string ValidationFileAllowedExtensions { get; set; } = String.Empty;
            public int? ValidationFileMaximumSize { get; set; }
            public string DefaultValue { get; set; } = String.Empty;
            public List<CheckoutAttributeValueDTO> CheckoutAttributeValue { get; set; }
            public List<CheckoutAttributeValueDTO> UpdateCheckoutAttributeValue { get; set; }
            public List<Guid> RemoveCheckAttributeValueIds { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, CheckoutAttributeDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<CheckoutAttributeDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentCheckoutAttribute = await _unitOfWorkAdministration.CheckoutAttrbiute.GetFullyById(request.CheckoutAttributeId, cancellationToken);

                if (currentCheckoutAttribute is null)
                {
                    throw new EntityNotFoundException($"Checkout attribute with id {request.CheckoutAttributeId} doesnt exist");
                }

                await createSpecificationCheckoutAttributeOption(request, cancellationToken);

                currentCheckoutAttribute.Name = request.Name;
                currentCheckoutAttribute.TextPrompt = request.TextPrompt;
                currentCheckoutAttribute.AttributeControlType = request.AttributeControlType;
                currentCheckoutAttribute.ShippableProductRequired = request.ShippableProductRequired;
                currentCheckoutAttribute.IsRequired = request.IsRequired;
                currentCheckoutAttribute.DisplayOrder = request.DisplayOrder;
                currentCheckoutAttribute.IsTaxExempt = request.IsTaxExempt;
                currentCheckoutAttribute.TaxCategoryId = request.TaxCategoryId;
                currentCheckoutAttribute.ConditionAttributeId = request.ConditionAttributeId;
                currentCheckoutAttribute.ValidationMaxLength = request.ValidationMaxLength;
                currentCheckoutAttribute.ValidationMinLength = request.ValidationMinLength;
                currentCheckoutAttribute.ValidationFileAllowedExtensions = request.ValidationFileAllowedExtensions;
                currentCheckoutAttribute.ValidationFileMaximumSize = request.ValidationFileMaximumSize;
                currentCheckoutAttribute.DefaultValue = request.DefaultValue;

                foreach (var checkoutAttributeValue in request.UpdateCheckoutAttributeValue)
                {
                    var currentCheckoutAttributeValue = currentCheckoutAttribute.CheckoutAttributeValue.Where(c => c.Id == checkoutAttributeValue.Id).First();

                    currentCheckoutAttributeValue.Name = checkoutAttributeValue.Name;
                    currentCheckoutAttributeValue.PriceAdjustment = checkoutAttributeValue.PriceAdjustment;
                    currentCheckoutAttributeValue.WeightAdjustment = checkoutAttributeValue.WeightAdjustment;
                    currentCheckoutAttributeValue.ColorSquaresRgb = checkoutAttributeValue.ColorSquaresRgb;
                    currentCheckoutAttributeValue.DisplayOrder = checkoutAttributeValue.DisplayOrder;
                    currentCheckoutAttributeValue.IsPreSelected = checkoutAttributeValue.IsPreSelected;
                    currentCheckoutAttributeValue.CheckoutAttributeValueLang = checkoutAttributeValue.CheckoutAttributeValueLang.Select(c => new CheckoutAttributeValueLangEntity
                    {
                        LanguageId = c.LanguageId,
                        Name = c.Name
                    }).ToList();
                }

                if (request.RemoveCheckAttributeValueIds is not null)
                {
                    foreach(var checkoutAttributeValueId in request.RemoveCheckAttributeValueIds)
                    {
                        _unitOfWorkAdministration.CheckoutAttrbiute.RemoveCheckoutAttributeValueById(checkoutAttributeValueId);
                    }
                }

                if (request.CheckoutAttributeValue is not null)
                {
                    foreach(var checkoutAttributeValue in request.CheckoutAttributeValue)
                    {
                        currentCheckoutAttribute.CheckoutAttributeValue.Add(CheckoutAttributeValueEntityFactory.CreateFromDto(checkoutAttributeValue));
                    }
                }

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = CheckoutAttributeDtoFactory.CreateFromEntity(currentCheckoutAttribute);

                return dto;
            }
            private async Task createSpecificationCheckoutAttributeOption(Command request, CancellationToken cancellationToken)
            {
                foreach (var checkoutAttributeValue in request.UpdateCheckoutAttributeValue)
                {
                    if (!await _unitOfWorkAdministration.CheckoutAttrbiute.ExistsAsync(checkoutAttributeValue.CheckoutAttributeId))
                    {
                        throw new EntityNotFoundException($"Checkout attribute with id: {checkoutAttributeValue.Id} doesnt exist");
                    }
                }

                foreach (var removeId in request.RemoveCheckAttributeValueIds)
                {
                    if (!await _unitOfWorkAdministration.CheckoutAttrbiute.CheckoutAttributeValueHasValueAsync(request.CheckoutAttributeId, removeId, cancellationToken))
                    {
                        throw new EntityNotFoundException($"Checkout attribute value with id {removeId} not parse with checkout attribute id {request.CheckoutAttributeId}");
                    }
                }
            }
        }



        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.CheckoutAttributeId).NotEqual(Guid.Empty);
            }
        }


    }
}
