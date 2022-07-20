using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Tag;
using JustCommerce.Domain.Entities.Products.Tags;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductTags.Command
{
    public static class UpdateProductTag
    {

        public sealed record Command() : IRequest<ProductTagDTO>
        {
            public Guid ProductTagId { get; set; }
            public List<ProductTagLangDTO> ProductTagLang { get; set; }
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
                
                foreach(var productTag in request.ProductTagLang)
                {
                    var tag = currentProductTag.ProductTagLang.Where(c => c.LanguageId == productTag.LanguageId && c.ProductTagId == productTag.ProductTagId).FirstOrDefault();
                    
                    if(tag is null)
                    {
                        var entity = new ProductTagLangEntity
                        {
                            LanguageId = productTag.LanguageId,
                            Name = productTag.Name,
                        };

                        currentProductTag.ProductTagLang.Add(entity);
                    }
                }

                var dto = new ProductTagDTO
                {
                    Id = currentProductTag.Id,
                    StoreId = currentProductTag.StoreId,
                    CreatedDate = currentProductTag.CreatedDate,
                    CreatedBy = currentProductTag.CreatedBy,
                    ProductTagLang = currentProductTag.ProductTagLang.Select(c => new ProductTagLangDTO
                    {
                        ProductTagId = c.ProductTagId,
                        LanguageId = c.LanguageId,
                        Name = c.Name
                    }).ToList()
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
