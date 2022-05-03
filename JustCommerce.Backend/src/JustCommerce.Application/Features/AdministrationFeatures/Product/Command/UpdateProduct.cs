using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Application.Common.Factories.DtoFactories.Product;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Product;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Command
{
    public static class UpdateProduct
    {

        public sealed record Command(Guid ProductId, Guid ProductTypeId, string Slug, bool Top, bool AvailabilityType, bool Active, bool Newsletter, Guid ShopId, List<ProductLangDTO> ProductLang, List<ProductFileDTO> ProductFileDto,
                                     ICollection<CategoryDTO>? Category) : IRequestWrapper<ProductDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, ProductDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IFtpFileManager _ftpFileManager;
            private readonly IWatermarkManager _watermarkManager;

            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IFtpFileManager ftpFileManager, IWatermarkManager watermarkManager)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _ftpFileManager = ftpFileManager;
                _watermarkManager = watermarkManager;
            }

            public async Task<ProductDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _unitOfWorkAdministration.Product.GetProductFullObject(request.ProductId, cancellationToken);

                if (product is null)
                {
                    throw new EntityNotFoundException($"Category with Id : {request.ProductId} doesn`t exists");
                }

                product.Slug = request.Slug;
                product.Top = request.Top;
                product.AvailabilityType = request.AvailabilityType;
                product.Active = request.Active;
                product.Newsletter = request.Newsletter;

                foreach (var lang in product.ProductLang)
                {
                    var newLang = request.ProductLang.Where(c => c.IsoCode == lang.IsoCode).FirstOrDefault();
                    if (newLang != null)
                    {
                        lang.Name = newLang.Name;
                        lang.IsoCode = newLang.IsoCode;
                        lang.Description = newLang.Description;
                        lang.Keywords = newLang.Keywords;
                        lang.Synonyms = newLang.Synonyms;
                        lang.Tags = newLang.Tags;
                        lang.MetaDescription = newLang.MetaDescription;
                        lang.ImageDescription = newLang.ImageDescription;
                        lang.MetaTitle = newLang.MetaTitle;
                        lang.ProductPropertyJson = newLang.ProductPropertyJason;

                        request.ProductLang.Remove(newLang);
                    }
                }

                if (request.ProductLang.Any())
                {
                    for (int i = 0; i < request.ProductLang.Count; i++)
                    {
                        var lang = ProductLangEntityFactory.CreateFromDto(request.ProductLang[i]);
                        product.ProductLang.Add(lang);
                    }
                }

                await _ftpFileManager.RemoveAllProductImage(request.ProductId, cancellationToken);

                var fileList = new List<ProductFileEntity>();

                foreach (var image in request.ProductFileDto)
                {
                    var path = await _ftpFileManager.SaveProductPhotoOnFtpAsync(image.Base64File, request.ProductId, image.FileName);

                    ProductFileEntity productFile = new ProductFileEntity()
                    {
                        Id = Guid.NewGuid(),
                        PhotoPath = path,
                        ProductColor = image.ProductColor,
                        ProductId = request.ProductId,
                    };
                    fileList.Add(productFile);
                }

                product.ProductFile = fileList;

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);
                
                return ProductDtoFactory.CreateFromEntity(product);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ProductId).NotEqual(Guid.Empty);
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }

    }
}
