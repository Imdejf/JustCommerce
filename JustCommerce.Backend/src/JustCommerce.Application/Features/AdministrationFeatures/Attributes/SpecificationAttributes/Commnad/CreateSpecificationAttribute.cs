using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Attributes.SpecificationAttributes;
using JustCommerce.Application.Common.Factories.DtoFactories.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Attributes.SpecificationAttributes;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.SpecificationAttributes.Commnad
{
    public static class CreateSpecificationAttribute
    {

        public sealed record Command() : IRequest<SpecificationAttributeDTO>
        {
            public Guid SpecificationAttributeGroupId { get; set; }
            public string Name { get; set; } = string.Empty;
            public int DisplayOrder { get; set; }

            public List<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; }
            public record SpecificationAttributeOption
            {
                public string Name { get; set; }
                public string ColorSquaresRgb { get; set; }
                public int DisplayOrder { get; set; }
                public ICollection<SpecificationAttributeOptionLang> SpecificationAttributeOptionLangs { get; set; }

                public record SpecificationAttributeOptionLang
                {
                    public Guid LanguageId { get; set; }
                    public string Name { get; set; } = String.Empty;
                }
            }
        }

        public sealed class Handler : IRequestHandler<Command, SpecificationAttributeDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SpecificationAttributeDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkAdministration.SpecificationAttributeGroup.ExistsAsync(request.SpecificationAttributeGroupId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Specification attribute group with id: {request.SpecificationAttributeGroupId} doesnt exist");
                }

                var newSpecificationAttribute = SpecificationAttributeEntityFactory.CreateSpecificationAttributeFromCommand(request);

                await _unitOfWorkAdministration.SpecificationAttribute.AddAsync(newSpecificationAttribute, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = SpecificationAttributeDtoFactory.CreateSpecificationAttributeFromEntity(newSpecificationAttribute);

                return dto;

            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.SpecificationAttributeGroupId).NotEqual(Guid.Empty);
            }
        }
    }
}
