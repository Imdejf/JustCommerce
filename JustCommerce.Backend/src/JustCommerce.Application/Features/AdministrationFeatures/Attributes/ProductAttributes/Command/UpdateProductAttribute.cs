using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Factories.DtoFactories.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command
{
    public static class UpdateProductAttribute
    {

        public sealed record Command() : IRequest<ProductAttributeDTO>
        {
            public Guid ProductAttributeId { get; set; }
            public Guid StoreId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            /// <summary>
            /// New data to add in ProductAttribute
            /// </summary>

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
                    public Guid PredefinedProductAttributeValueId { get; set; }
                    public Guid LanguageId { get; set; }
                    public string Name { get; set; } = String.Empty;
                }
            }

            /// <summary>
            /// Data to update ProductAttribute
            /// </summary>
            public List<UpdatePredefinedProductAttributeValue> UpdatePredefinedProductAttributeValues { get; set; }
            public record UpdatePredefinedProductAttributeValue
            {
                public Guid PredefinedProductAttributeValueId { get; set; }
                public string Name { get; set; } = string.Empty;
                public decimal PriceAdjustment { get; set; }
                public bool PriceAdjustmentUsePercentage { get; set; }
                public decimal WeightAdjustment { get; set; }
                public decimal Cost { get; set; }
                public bool IsPreSelected { get; set; }
                public int DisplayOrder { get; set; }

                public List<UpdatePredefinedProductAttributeValueLang> UpdatePredefinedProductAttributeValueLangs { get; set; }
                public record UpdatePredefinedProductAttributeValueLang
                {
                    public Guid LanguageId { get; set; }
                    public string Name { get; set; } = String.Empty;
                }
            }
        }
        public sealed class Handler : IRequestHandler<Command, ProductAttributeDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet, IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ProductAttributeDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentProductAttribute = await _unitOfWorkAdministration.ProductAttribute.GetFullyProductAttributeAsync(request.ProductAttributeId, cancellationToken);

                if (currentProductAttribute is null)
                {
                    throw new EntityNotFoundException($"Product attribute with id: {request.ProductAttributeId} doesnt exist");
                }

                await ensureThatSendDataValidAsync(request, cancellationToken);

                currentProductAttribute.Name = request.Name;
                currentProductAttribute.Description = request.Description;
                currentProductAttribute.LastModifiedDate = DateTime.Now;

                foreach (var lang in request.ProductAttributeLangs)
                {
                    var currentLang = currentProductAttribute.ProductAttributeLang.Where(c => c.LanguageId == lang.LanguageId).FirstOrDefault();
                    if(currentLang is not null)
                    {
                        currentLang.Name = lang.Name;
                    }
                    else
                    {
                        currentProductAttribute.ProductAttributeLang.Add(new ProductAttributeLangEntity
                        {
                            LanguageId = lang.LanguageId,
                            ProductAttributeId = currentProductAttribute.Id,
                            Name = lang.Name
                        });
                    }
                }

                if(request.PredefinedProductAttributeValues != null)
                {
                    currentProductAttribute.PredefinedProductAttributeValue.AddRange(await createPredefinedProductAttributeValues(request, cancellationToken));
                }
               
                if(request.UpdatePredefinedProductAttributeValues is not null)
                {
                    foreach(var value in request.UpdatePredefinedProductAttributeValues)
                    {
                        var currentProductAttributeToUpdate = currentProductAttribute.PredefinedProductAttributeValue.Where(c => c.Id == value.PredefinedProductAttributeValueId).First();

                        currentProductAttributeToUpdate.Name = value.Name;
                        currentProductAttributeToUpdate.PriceAdjustment = value.PriceAdjustment;
                        currentProductAttributeToUpdate.WeightAdjustment = value.WeightAdjustment;
                        currentProductAttributeToUpdate.PriceAdjustmentUsePercentage = value.PriceAdjustmentUsePercentage;
                        currentProductAttributeToUpdate.Cost = value.Cost;
                        currentProductAttributeToUpdate.DisplayOrder = value.DisplayOrder;
                        currentProductAttributeToUpdate.IsPreSelected = value.IsPreSelected;
                        currentProductAttributeToUpdate.PriceAdjustment = value.PriceAdjustment;
                        currentProductAttributeToUpdate.PredefinedProductAttributeValueLang = value.UpdatePredefinedProductAttributeValueLangs.Select(c => new PredefinedProductAttributeValueLangEntity
                        {
                            LanguageId = c.LanguageId,
                            Name = c.Name,
                        }).ToList();
                    }
                }

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = ProductAttributeDtoFactory.CreateFromProductAttributeEntity(currentProductAttribute);

                return dto;
            }

            private async Task<List<PredefinedProductAttributeValueEntity>> createPredefinedProductAttributeValues(Command request, CancellationToken cancellationToken)
            {
                List<PredefinedProductAttributeValueEntity> predefinedProductAttributeValues = new List<PredefinedProductAttributeValueEntity>();

                foreach(var predefinedValue in request.PredefinedProductAttributeValues)
                {
                    var newPredefinedValue = new PredefinedProductAttributeValueEntity
                    {
                        Name = predefinedValue.Name,
                        Cost = predefinedValue.Cost,
                        DisplayOrder = predefinedValue.DisplayOrder,
                        IsPreSelected = predefinedValue.IsPreSelected,
                        PriceAdjustment = predefinedValue.PriceAdjustment,
                        PriceAdjustmentUsePercentage = predefinedValue.PriceAdjustmentUsePercentage,
                        WeightAdjustment = predefinedValue.WeightAdjustment,
                        PredefinedProductAttributeValueLang = predefinedValue.PredefinedProductAttributeValueLangs.Select(c => new PredefinedProductAttributeValueLangEntity
                        {
                            LanguageId = c.LanguageId,
                            Name = c.Name,
                        }).ToList()
                    };
                    predefinedProductAttributeValues.Add(newPredefinedValue);
                }

                return predefinedProductAttributeValues;
            }

            private async Task ensureThatSendDataValidAsync(Command request, CancellationToken cancellationToken)
            {
                foreach (var lang in request.ProductAttributeLangs)
                {
                    if (!await _unitOfWorkManagmenet.Language.ExistsAsync(lang.LanguageId))
                    {
                        throw new EntityNotFoundException($"Language with id: {lang.LanguageId} doesnt exist");
                    }
                }

                foreach (var predefinedProductAttributeValue in request.PredefinedProductAttributeValues)
                {
                    foreach (var lang in predefinedProductAttributeValue.PredefinedProductAttributeValueLangs)
                    {
                        if (!await _unitOfWorkManagmenet.Language.ExistsAsync(lang.LanguageId))
                        {
                            throw new EntityNotFoundException($"Language with id: {lang.LanguageId} doesnt exist");
                        }
                    }
                }

                foreach (var predefinedProductAttributeValue in request.UpdatePredefinedProductAttributeValues)
                {
                    foreach (var lang in predefinedProductAttributeValue.UpdatePredefinedProductAttributeValueLangs)
                    {
                        if (!await _unitOfWorkManagmenet.Language.ExistsAsync(lang.LanguageId))
                        {
                            throw new EntityNotFoundException($"Language with id: {lang.LanguageId} doesnt exist");
                        }
                    }
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
