﻿using JustCommerce.Application.Common.DTOs.Product.Product;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Application.Common.Factories.DtoFactories.Product.Attributes.Product
{
    public static class ProductDtoFactory
    {
        public static ProductDTO CreateFromEntity(ProductEntity entity)
        {
            return new ProductDTO
            {
                StoreId = entity.StoreId,
                Deleted = entity.Deleted,
                DeliveryDateId = entity.DeliveryDateId,
                DisableBuyButton = entity.DisableBuyButton,
                DisableWishlistButton = entity.DisableWishlistButton,
                DisplayOrder = entity.DisplayOrder,
                DisplayStockAvailability = entity.DisplayStockAvailability,
                DisplayStockQuantity = entity.DisplayStockQuantity,
                AvailableEndDateTimeUtc = entity.AvailableEndDateTimeUtc,
                AvailableStartDateTimeUtc = entity.AvailableStartDateTimeUtc,
                HasDiscountsApplied = entity.HasDiscountsApplied,
                MarkAsNewEndDateTimeUtc = entity.MarkAsNewEndDateTimeUtc,
                MarkAsNewStartDateTimeUtc = entity.MarkAsNewStartDateTimeUtc,
                PreOrderAvailabilityStartDateTimeUtc = entity.PreOrderAvailabilityStartDateTimeUtc,
                AdditionalShippingCharge = entity.AdditionalShippingCharge,
                AdminComment = entity.AdminComment,
                AllowAddingOnlyExistingAttributeCombinations = entity.AllowAddingOnlyExistingAttributeCombinations,
                AllowBackInStockSubscriptions = entity.AllowBackInStockSubscriptions,
                AllowCustomerReviews = entity.AllowCustomerReviews,
                AllowedQuantities = entity.AllowedQuantities,
                ApprovedRatingSum = entity.ApprovedRatingSum,
                ApprovedTotalReviews = entity.ApprovedTotalReviews,
                AvailableForPreOrder = entity.AvailableForPreOrder,
                BackorderMode = entity.BackorderMode,
                CallForPrice = entity.CallForPrice,
                CustomerEntersPrice = entity.CustomerEntersPrice,
                GiftCardType = entity.GiftCardType,
                GTIN = entity.GTIN,
                Height = entity.Height,
                HasTierPrices = entity.HasTierPrices,
                IsFreeShipping = entity.IsFreeShipping,
                ShowOnHomepage = entity.ShowOnHomepage,
                IsGiftCard = entity.IsGiftCard,
                IsRental = entity.IsGiftCard,
                IsShipEnabled = entity.IsGiftCard,
                IsTelecommunicationsOrBroadcastingOrElectronicServices = entity.IsTelecommunicationsOrBroadcastingOrElectronicServices,
                IsTaxExempt = entity.IsTaxExempt,
                Length = entity.Length,
                ManageInventoryMethod = entity.ManageInventoryMethod,
                LowStockActivity = entity.LowStockActivity,
                MarkAsNew = entity.MarkAsNew,
                ManufacturerPartNumber = entity.ManufacturerPartNumber,
                MaximumCustomerEnteredPrice = entity.MaximumCustomerEnteredPrice,
                MinimumCustomerEnteredPrice = entity.MinimumCustomerEnteredPrice,
                MinStockQuantity = entity.MinStockQuantity,
                Name = entity.Name,
                NotApprovedRatingSum = entity.NotApprovedRatingSum,
                NotApprovedTotalReviews = entity.NotApprovedTotalReviews,
                NotifyAdminForQuantityBelow = entity.NotifyAdminForQuantityBelow,
                NotReturnable = entity.NotReturnable,
                OldPrice = entity.OldPrice,
                OrderMaximumQuantity = entity.OrderMaximumQuantity,
                OrderMinimumQuantity = entity.OrderMinimumQuantity,
                OverriddenGiftCardAmount = entity.OverriddenGiftCardAmount,
                ParentGroupedProductId = entity.ParentGroupedProductId,
                Price = entity.Price,
                ProductCost = entity.ProductCost,
                ProductAvailabilityRangeId = entity.ProductAvailabilityRangeId,
                ProductType = entity.ProductType,
                Published = entity.Published,
                RentalPricePeriod = entity.RentalPricePeriod,
                ShipSeparately = entity.ShipSeparately,
                SKU = entity.SKU,
                StockQuantity = entity.StockQuantity,
                RentalPriceLength = entity.StockQuantity,
                UseMultipleWarehouses = entity.UseMultipleWarehouses,
                Weight = entity.Weight,
                Width = entity.Width,
                TaxCategoryId = entity.TaxCategoryId,
                VendorId = entity.VendorId,
                VisibleIndividually = entity.VisibleIndividually,
                ProductLang = entity.ProductLang.Select(c => ProductLangDtoFactory.CreateFromEntity(c)).ToList()
            };
        }
    }
}