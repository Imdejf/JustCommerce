using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Attributes.SpecificationAttributes;
using JustCommerce.Application.Common.DTOs.Product.Manufacturer;
using JustCommerce.Application.Common.DTOs.Product.Product;
using JustCommerce.Application.Common.DTOs.Product.Tag;
using JustCommerce.Application.Common.Factories.DtoFactories.Product.Attributes.Product;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Product;
using JustCommerce.Domain.Entities.Products.Tags;
using JustCommerce.Domain.Enums.Product;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Product.Command
{
    public static class CreateProduct
    {

        public sealed record Command() : IRequest<ProductDTO>
        {
            public Guid StoreId { get; set; }
            public ICollection<SpecificationAttributeDTO>? ProductSpecificationAttribute { get; set; }
            public ProductType ProductType { get; set; }
            public Guid? ParentGroupedProductId { get; set; }
            public bool VisibleIndividually { get; set; }
            public string Name { get; set; }
            public string AdminComment { get; set; }
            public Guid VendorId { get; set; }
            public bool ShowOnHomepage { get; set; }
            public bool AllowCustomerReviews { get; set; }
            public int ApprovedRatingSum { get; set; }
            public int NotApprovedRatingSum { get; set; }
            public int ApprovedTotalReviews { get; set; }
            public int NotApprovedTotalReviews { get; set; }
            public string SKU { get; set; }
            public string ManufacturerPartNumber { get; set; }
            public string GTIN { get; set; }
            public bool IsGiftCard { get; set; }
            public GiftCardType GiftCardType { get; set; }
            public decimal? OverriddenGiftCardAmount { get; set; }
            public bool IsRental { get; set; }
            public int RentalPriceLength { get; set; }
            public RentalPricePeriod RentalPricePeriod { get; set; }
            public bool IsShipEnabled { get; set; }
            public bool IsFreeShipping { get; set; }
            public bool ShipSeparately { get; set; }
            public decimal AdditionalShippingCharge { get; set; }
            public Guid? DeliveryDateId { get; set; }
            public bool IsTaxExempt { get; set; }
            public Guid? TaxCategoryId { get; set; }
            public bool IsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }
            public ManageInventoryMethod ManageInventoryMethod { get; set; }
            public Guid? ProductAvailabilityRangeId { get; set; }
            public bool UseMultipleWarehouses { get; set; }
            public List<Guid>? ProductWarehouseInventoryId { get; set; }
            public int StockQuantity { get; set; }
            public bool DisplayStockAvailability { get; set; }
            public bool DisplayStockQuantity { get; set; }
            public int MinStockQuantity { get; set; }
            public LowStockActivity LowStockActivity { get; set; }
            public int NotifyAdminForQuantityBelow { get; set; }
            public BackorderMode BackorderMode { get; set; }
            public bool AllowBackInStockSubscriptions { get; set; }
            public int OrderMinimumQuantity { get; set; }
            public int OrderMaximumQuantity { get; set; }
            public string AllowedQuantities { get; set; }
            public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }
            public bool NotReturnable { get; set; }
            public bool DisableBuyButton { get; set; }
            public bool DisableWishlistButton { get; set; }
            public bool AvailableForPreOrder { get; set; }
            public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
            public bool CallForPrice { get; set; }
            public decimal Price { get; set; }
            public decimal OldPrice { get; set; }
            public decimal ProductCost { get; set; }
            public bool CustomerEntersPrice { get; set; }
            public decimal MinimumCustomerEnteredPrice { get; set; }
            public decimal MaximumCustomerEnteredPrice { get; set; }
            public bool MarkAsNew { get; set; }
            public DateTime? MarkAsNewStartDateTimeUtc { get; set; }
            public DateTime? MarkAsNewEndDateTimeUtc { get; set; }
            public bool HasTierPrices { get; set; }
            public bool HasDiscountsApplied { get; set; }
            public decimal Weight { get; set; }
            public decimal Length { get; set; }
            public decimal Width { get; set; }
            public decimal Height { get; set; }
            public DateTime? AvailableStartDateTimeUtc { get; set; }
            public DateTime? AvailableEndDateTimeUtc { get; set; }
            public int DisplayOrder { get; set; }
            public bool Published { get; set; }
            public bool Deleted { get; set; }
            public DateTime? CreatedOnUtc { get; set; }

            public DateTime? UpdatedOnUtc { get; set; }
            public ICollection<ProductLangDTO> ProductLang { get; set; }
            public ICollection<ProductTagDTO>? ProductTag { get; set; }
            public ICollection<Guid>? ProductCategoryId { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, ProductDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<ProductDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }

                var newProduct = ProductEntityFactory.CreateFromCommand(request);
                newProduct.CreatedOnUtc = DateTime.Now;

                await _unitOfWorkAdministration.Product.AddAsync(newProduct, cancellationToken);

                foreach (var productTag in request.ProductTag)
                {
                    var tag = await _unitOfWorkAdministration.ProductTag.GetProductTagByNameAsync(productTag.Name, productTag.LanguageId, cancellationToken);
                    
                    if(tag is null)
                    {
                        await _unitOfWorkAdministration.ProductTag.AddAsync(new ProductTagEntity
                        {
                            StoreId = request.StoreId,
                            CreatedDate = DateTime.Now,
                            LanguageId = productTag.LanguageId,
                            Name = productTag.Name,
                            ProductProductTag = new List<ProductProductTagEntity>()
                            {
                                new ProductProductTagEntity
                                {
                                    ProductId = newProduct.Id,
                                }
                            }
                        });
                    }
                    else
                    {
                        tag.ProductProductTag.Add(new ProductProductTagEntity
                        {
                            ProductId = newProduct.Id
                        });
                    }
                }

                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = ProductDtoFactory.CreateFromEntity(newProduct);

                return dto;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.StoreId).NotEqual(Guid.Empty);
            }
        }


    }
}
