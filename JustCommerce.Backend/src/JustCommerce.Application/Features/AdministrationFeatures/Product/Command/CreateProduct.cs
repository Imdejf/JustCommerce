using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Common;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Command
{
    public static class CreateProduct
    {

        public sealed record Command(Guid ProductTypeId, string Slug, bool Top, bool AvailabilityType, bool Active, bool Newsletter, List<ProductLangDTO> ProductLang,
                                     List<Guid> CategoryId, List<Guid> SubCategoryId) : IRequestWrapper<Unit>;

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
                                                .Select(c => ProductLangEntityFactory.CreateFromData(newProduct.Id, c.Description, c.ImageDescription, c.Keywords, c.MetaDescription,
                                                                                                    c.MetaTitle, c.Synonyms, c.Tags, c.Name, c.IsoCode))
                                                                                     .ToList();

                //List<ProductCategoryEntity> productCategoryList = new List<ProductCategoryEntity>();

                //foreach (var category in request.CategoryId)
                //{
                //    var productCategory = new ProductCategoryEntity() { ProductId = newProduct.Id, CategoryId = category };
                //    productCategoryList.Add(productCategory);
                //}

                //newProduct.ProductCategory = productCategoryList;

                await _unitOfWorkAdministration.Product.AddAsync(newProduct, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
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
