using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Command
{
    public static class CreateProduct
    {

        public sealed record Command(Guid ProductTypeId, string Slug, bool Top, bool AvailabilityType, bool Active, bool Newsletter, List<ProductLangDTO> ProductLang) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               var exist = await _unitOfWorkAdministration.Product.ExistSlugAsync(request.Slug);

                if (exist)
                {
                    throw new EntityNotFoundException($"Slug exists");
                }

                var newProduct = ProductEntityFactory.CreateFromCategoryCommand(request);

                newProduct.ProductLang = request.ProductLang
                                                .Select(c => ProductLangEntityFactory.CreateFromData(newProduct.Id, c.Description, c.ImageDescription, c.Keywords, c.MetaDescription
                                                                                                    c.MetaTitle, c.Synonyms, c.Tags, c.Name, c.IsoCode))
                                                                                     .ToList();
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
