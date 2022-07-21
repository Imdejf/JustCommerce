using JustCommerce.Application.Features.AdministrationFeatures.Product.Product.Command;
using JustCommerce.Domain.Entities.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.EntitiesFactories.Product.Product
{
    public static class ProductEntityFactory
    {
        public static ProductEntity CreateFromCommand(CreateProduct.Command command)
        {
            return new ProductEntity
            {
                StoreId = command.StoreId,
                Deleted = command.Deleted,
                DeliveryDateId = command.DeliveryDateId,
                DisableBuyButton = command.DisableBuyButton,
                DisableWishlistButton = command.DisableWishlistButton,
                DisplayOrder = command.DisplayOrder,
                DisplayStockAvailability = command.DisplayStockAvailability,
                DisplayStockQuantity = command.DisplayStockQuantity,
                AvailableEndDateTimeUtc = command.AvailableEndDateTimeUtc,
                AvailableStartDateTimeUtc = command.AvailableStartDateTimeUtc,
                HasDiscountsApplied = command.HasDiscountsApplied,
                MarkAsNewEndDateTimeUtc = command.MarkAsNewEndDateTimeUtc,
                MarkAsNewStartDateTimeUtc = command.MarkAsNewStartDateTimeUtc,
                PreOrderAvailabilityStartDateTimeUtc = command.PreOrderAvailabilityStartDateTimeUtc,
                AdditionalShippingCharge = command.AdditionalShippingCharge,
                AdminComment = command.AdminComment,
                AllowAddingOnlyExistingAttributeCombinations = command.AllowAddingOnlyExistingAttributeCombinations,
                AllowBackInStockSubscriptions = command.AllowBackInStockSubscriptions,
                AllowCustomerReviews = command.AllowCustomerReviews,
                AllowedQuantities = command.AllowedQuantities,
                ApprovedRatingSum = command.ApprovedRatingSum,
                ApprovedTotalReviews = command.ApprovedTotalReviews,
                AvailableForPreOrder = command.AvailableForPreOrder,
                BackorderMode = command.BackorderMode,
                CallForPrice = command.CallForPrice,
                CustomerEntersPrice = command.CustomerEntersPrice,
                GiftCardType = command.GiftCardType,
                GTIN = command.GTIN,
                Height = command.Height,
                HasTierPrices = command.HasTierPrices,
                IsFreeShipping = command.IsFreeShipping,
                ShowOnHomepage = command.ShowOnHomepage,
                IsGiftCard = command.IsGiftCard,
                IsRental = command.IsGiftCard,
                IsShipEnabled = command.IsGiftCard,
                IsTelecommunicationsOrBroadcastingOrElectronicServices = command.IsTelecommunicationsOrBroadcastingOrElectronicServices,
                IsTaxExempt = command.IsTaxExempt,
                Length = command.Length,
                ManageInventoryMethod = command.ManageInventoryMethod,
                LowStockActivity = command.LowStockActivity,
                MarkAsNew = command.MarkAsNew,
                ManufacturerPartNumber = command.ManufacturerPartNumber,
                MaximumCustomerEnteredPrice = command.MaximumCustomerEnteredPrice,
                MinimumCustomerEnteredPrice = command.MinimumCustomerEnteredPrice,
                MinStockQuantity = command.MinStockQuantity,
                Name = command.Name,
                NotApprovedRatingSum = command.NotApprovedRatingSum,
                NotApprovedTotalReviews = command.NotApprovedTotalReviews,
                NotifyAdminForQuantityBelow = command.NotifyAdminForQuantityBelow,
                NotReturnable = command.NotReturnable,
                OldPrice = command.OldPrice,
                OrderMaximumQuantity = command.OrderMaximumQuantity,
                OrderMinimumQuantity = command.OrderMinimumQuantity,
                OverriddenGiftCardAmount = command.OverriddenGiftCardAmount,
                ParentGroupedProductId = command.ParentGroupedProductId,
                Price = command.Price,
                ProductCost = command.ProductCost,
                ProductAvailabilityRangeId = command.ProductAvailabilityRangeId,
                ProductType = command.ProductType,
                Published = command.Published,
                RentalPricePeriod = command.RentalPricePeriod,
                ShipSeparately = command.ShipSeparately,
                SKU = command.SKU,
                StockQuantity = command.StockQuantity,
                RentalPriceLength = command.StockQuantity,
                UseMultipleWarehouses = command.UseMultipleWarehouses,
                Weight = command.Weight,
                Width = command.Width,
                TaxCategoryId = command.TaxCategoryId,
                VendorId = command.VendorId,
                VisibleIndividually = command.VisibleIndividually,
                ProductLang = command.ProductLang.Select(c => ProductLangEntityFactory.CreateFromDto(c)).ToList()
            };
        }
    }
}
