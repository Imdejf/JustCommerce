using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Category;
using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Entities.Product;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Models;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Command
{
    public static class CreateProduct
    {

        public sealed record Command(Guid ProductTypeId, string Slug, bool Top, bool AvailabilityType, bool Active, bool Newsletter,Guid ShopId, List<ProductSellableDTO> ProductSellable, List<ProductLangDTO> ProductLang, List<ProductFileDTO> ProductFileDto,
                                     ICollection<CategoryDTO> Category) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
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

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var exist = await _unitOfWorkAdministration.Product.ExistSlugAsync(request.Slug);

                if (exist)
                {
                    throw new EntityNotFoundException($"Slug exists");
                }

                var newProduct = ProductEntityFactory.CreateFromProductCommand(request);


                newProduct.ProductLang = request.ProductLang
                                                .Select(c => ProductLangEntityFactory.CreateFromData(newProduct.Id, c.Description, c.ImageDescription, c.Keywords, c.MetaDescription,
                                                                                                    c.MetaTitle, c.Synonyms, c.Tags, c.Name, c.IsoCode))
                                                                                     .ToList();

                await _unitOfWorkAdministration.Product.AddAsync(newProduct, cancellationToken);

                foreach (var base64Image in request.ProductFileDto)
                {
                    base64Image.Base64File = await _watermarkManager.AddWatermarkToPicture(base64Image.Base64File, cancellationToken);
                }

                foreach (var iconBase64Image in request.ProductSellable)
                {
                    iconBase64Image.Base64File = await _watermarkManager.AddWatermarkToPicture(iconBase64Image.Base64File, cancellationToken);
                }

                var fileList = new List<ProductFileEntity>();

                foreach(var image in request.ProductFileDto)
                {
                    var path = await _ftpFileManager.SaveProductPhotoOnFtpAsync(image.Base64File, newProduct.Id, image.FileName, cancellationToken);

                    ProductFileEntity productFile = new ProductFileEntity()
                    {
                        Id = Guid.NewGuid(),
                        PhotoPath = path,
                        ProductColor = image.ProductColor,
                        ProductId = newProduct.Id,
                    };
                    fileList.Add(productFile);
                }

                foreach (var iconImage in request.ProductSellable)
                {
                    ProductColor color = (ProductColor)iconImage.ProductColor;
                    string iconPath = await _ftpFileManager.SaveProductIconOnFtpAsync(iconImage.Base64File, newProduct.Id, $"{iconImage.FileName}",color.ToString(), cancellationToken);
                    iconImage.IconPath = iconPath;
                }

                newProduct.ProductSellable = request.ProductSellable
                                    .Select(c => ProductSellableEntityFactory.CreateFromDto(c))
                                    .ToList();

                await _unitOfWorkAdministration.ProductFile.AddRangePhoto(fileList, cancellationToken);
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
