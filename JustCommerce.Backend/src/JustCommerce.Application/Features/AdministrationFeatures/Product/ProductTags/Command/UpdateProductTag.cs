using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Tag;
using JustCommerce.Application.Common.Factories.DtoFactories.Product.Attributes.Product;
using JustCommerce.Domain.Entities.Products.Tags;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.ProductTags.Command
{
    public static class UpdateProductTag
    {

        public sealed record Command() : IRequest<ProductTagDTO>
        {
            public Guid ProductTagId { get; set; }
            public string Name { get; set; } = String.Empty;
            public Guid LanguageId { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, ProductTagDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ProductTagDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentProductTag = await _unitOfWorkAdministration.ProductTag.GetFullyAsync(request.ProductTagId, cancellationToken);
                if (currentProductTag is null)
                {
                    throw new EntityNotFoundException($"Produt tag with id {request.ProductTagId} doesnt exist");
                }

                var tag = await _unitOfWorkAdministration.ProductTag.GetByIdAsync(request.ProductTagId, cancellationToken);

                tag.Name = request.Name;

                var dto = new ProductTagDTO
                {
                    StoreId = tag.StoreId,
                    CreatedBy = tag.CreatedBy,
                    Name = request.Name,
                };

                return dto;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ProductTagId).NotEqual(Guid.Empty);
            }
        }
    }
}
