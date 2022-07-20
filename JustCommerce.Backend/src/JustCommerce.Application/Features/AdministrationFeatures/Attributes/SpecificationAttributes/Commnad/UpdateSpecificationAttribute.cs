using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Attributes.SpecificationAttributes;
using JustCommerce.Application.Common.Factories.DtoFactories.Attributes.ProductAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.SpecificationAttributes.Commnad
{
    public sealed class UpdateSpecificationAttribute
    {

        public sealed record Command() : IRequest<SpecificationAttributeDTO>
        {
            public Guid SpecificationAttributeId { get; set; }
            public Guid SpecificationAttributeGroupId { get; set; }
            public string Name { get; set; } = string.Empty;
            public int DisplayOrder { get; set; }

            public List<SpecificationAttributeOption>? SpecificationAttributeOptions { get; set; }
            public record SpecificationAttributeOption
            {
                public string Name { get; set; } = String.Empty;
                public string ColorSquaresRgb { get; set; } = String.Empty;
                public int DisplayOrder { get; set; }
                public ICollection<SpecificationAttributeOptionLang> SpecificationAttributeOptionLangs { get; set; }

                public record SpecificationAttributeOptionLang
                {
                    public Guid LanguageId { get; set; }
                    public string Name { get; set; } = String.Empty;
                }
            }

            public List<UpdateSpecificationAttributeOption>? UpdateSpecificationAttributeOptions { get; set; }
            public record UpdateSpecificationAttributeOption
            {
                public Guid SpecificationAttributeOptionId { get; set; }
                public string Name { get; set; } = String.Empty;
                public string ColorSquaresRgb { get; set; } = String.Empty;
                public int DisplayOrder { get; set; }
                public ICollection<UpdateSpecificationAttributeOptionLang> UpdateSpecificationAttributeOptionLangs { get; set; }

                public record UpdateSpecificationAttributeOptionLang
                {
                    public Guid LanguageId { get; set; }
                    public string Name { get; set; } = String.Empty;
                }
            }

            public List<Guid> RemoveSpecificationAttributeOptionIds { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, SpecificationAttributeDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet = null)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SpecificationAttributeDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentSpecificationAttribute = await _unitOfWorkAdministration.SpecificationAttribute.GetFullyById(request.SpecificationAttributeId, cancellationToken);

                if (currentSpecificationAttribute is null)
                {
                    throw new EntityNotFoundException($"Specification attribute with id: {request.SpecificationAttributeGroupId} doesnt exist");
                }

                if (!await _unitOfWorkAdministration.SpecificationAttributeGroup.ExistsAsync(request.SpecificationAttributeGroupId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Specification attribute group with id: {request.SpecificationAttributeGroupId} doesnt exist");
                }

                await ensureThatSendDataValidAsync(request, cancellationToken);

                currentSpecificationAttribute.Name = request.Name;
                currentSpecificationAttribute.DisplayOrder = request.DisplayOrder;
                currentSpecificationAttribute.SpecificationAttributeGroupId = request.SpecificationAttributeGroupId;

                if(request.SpecificationAttributeOptions is not null)
                {
                    await createSpecificationAttributeOption(request, cancellationToken);
                }


                if (request.UpdateSpecificationAttributeOptions is not null)
                {
                    foreach (var updateSpecificationAttributeOptions in request.UpdateSpecificationAttributeOptions)
                    {
                        var currentSpecificationAttributeToUpdate = currentSpecificationAttribute.SpecificationAttributeOption.Where(c => c.Id == updateSpecificationAttributeOptions.SpecificationAttributeOptionId).First();

                        currentSpecificationAttributeToUpdate.Name = updateSpecificationAttributeOptions.Name;
                        currentSpecificationAttributeToUpdate.ColorSquaresRgb = updateSpecificationAttributeOptions.ColorSquaresRgb;
                        currentSpecificationAttributeToUpdate.DisplayOrder = updateSpecificationAttributeOptions.DisplayOrder;
                        currentSpecificationAttributeToUpdate.SpecificationAttributeOptionLang = updateSpecificationAttributeOptions.UpdateSpecificationAttributeOptionLangs.Select(c => new SpecificationAttributeOptionLangEntity
                        {
                            LanguageId = c.LanguageId,
                            Name = c.Name
                        }).ToList();

                    }
                }

                try
                {
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                }
                catch(Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }

                var dto = SpecificationAttributeDtoFactory.CreateSpecificationAttributeFromEntity(currentSpecificationAttribute);

                return dto;
            }

            private async Task createSpecificationAttributeOption(Command request, CancellationToken cancellationToken)
            {
                var currentSpecificationAttribute = await _unitOfWorkAdministration.SpecificationAttribute.GetByIdAsync(request.SpecificationAttributeId, cancellationToken);
                List<SpecificationAttributeOptionEntity> specificationAttributeOptionList = new List<SpecificationAttributeOptionEntity>();

                foreach (var specificationAttributeOption in request.SpecificationAttributeOptions)
                {
                    var newSpecificationAttributeOption = new SpecificationAttributeOptionEntity
                    {
                        SpecificationAttributeId = currentSpecificationAttribute.Id,
                        ColorSquaresRgb = specificationAttributeOption.ColorSquaresRgb,
                        DisplayOrder = specificationAttributeOption.DisplayOrder,
                        Name = specificationAttributeOption.Name,
                        SpecificationAttributeOptionLang = specificationAttributeOption.SpecificationAttributeOptionLangs.Select(c => new SpecificationAttributeOptionLangEntity
                        {
                            LanguageId = c.LanguageId,
                            Name = c.Name
                        }).ToList(),
                    };

                    specificationAttributeOptionList.Add(newSpecificationAttributeOption);
                }

                currentSpecificationAttribute.SpecificationAttributeOption.AddRange(specificationAttributeOptionList);
            }

            private async Task ensureThatSendDataValidAsync(Command request, CancellationToken cancellationToken)
            {
                foreach (var specificationAttributeOptions in request.SpecificationAttributeOptions)
                {
                    foreach (var lang in specificationAttributeOptions.SpecificationAttributeOptionLangs)
                    {
                        if (!await _unitOfWorkManagmenet.Language.ExistsAsync(lang.LanguageId, cancellationToken))
                        {
                            throw new EntityNotFoundException($"Language with id: {lang.LanguageId} doesnt exist");
                        }
                    }
                }

                foreach (var updateSpecificationAttributeOptions in request.UpdateSpecificationAttributeOptions)
                {
                    if (!await _unitOfWorkAdministration.SpecificationAttributeOption.ExistsAsync(updateSpecificationAttributeOptions.SpecificationAttributeOptionId, cancellationToken))
                    {
                        throw new EntityNotFoundException($"Specification attribute option with id: {request.SpecificationAttributeGroupId} doesnt exist");
                    }

                    foreach (var lang in updateSpecificationAttributeOptions.UpdateSpecificationAttributeOptionLangs)
                    {
                        if (!await _unitOfWorkManagmenet.Language.ExistsAsync(lang.LanguageId, cancellationToken))
                        {
                            throw new EntityNotFoundException($"Language with id: {lang.LanguageId} doesnt exist");
                        }
                    }
                }

                foreach (var removeSpecificationAttributeOptionId in request.RemoveSpecificationAttributeOptionIds)
                {
                    if (await _unitOfWorkAdministration.SpecificationAttributeOption.ExistsAsync(removeSpecificationAttributeOptionId, cancellationToken))
                    {
                        throw new EntityNotFoundException($"Specification attribute option with id: {request.SpecificationAttributeGroupId} doesnt exist");
                    }
                }
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.SpecificationAttributeGroupId).NotEqual(Guid.Empty);
                RuleFor(c => c.SpecificationAttributeId).NotEqual(Guid.Empty);
                RuleFor(c => c.Name).NotEmpty();
            }
        }
    }
}
