using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Added_Checkout_Attribute_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStoreEntity_Store_StoreId",
                table: "UserStoreEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStoreEntity_Users_UserId",
                table: "UserStoreEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStoreEntity",
                table: "UserStoreEntity");

            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.EnsureSchema(
                name: "directory");

            migrationBuilder.EnsureSchema(
                name: "shipping");

            migrationBuilder.EnsureSchema(
                name: "tax");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.RenameTable(
                name: "UserStoreEntity",
                newName: "UserStore",
                newSchema: "identity");

            migrationBuilder.RenameIndex(
                name: "IX_UserStoreEntity_UserId",
                schema: "identity",
                table: "UserStore",
                newName: "IX_UserStore_UserId");

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalShippingCharge",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                schema: "product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AllowAddingOnlyExistingAttributeCombinations",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowBackInStockSubscriptions",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowCustomerReviews",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AllowedQuantities",
                schema: "product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ApprovedRatingSum",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedTotalReviews",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableEndDateTimeUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableForPreOrder",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableStartDateTimeUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackorderMode",
                schema: "product",
                table: "Product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CallForPrice",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "CustomerEntersPrice",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryDateId",
                schema: "product",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "DisableBuyButton",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisableWishlistButton",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayStockAvailability",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayStockQuantity",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GTIN",
                schema: "product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GiftCardType",
                schema: "product",
                table: "Product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasDiscountsApplied",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTierPrices",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsFreeShipping",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGiftCard",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRental",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShipEnabled",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxExempt",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTelecommunicationsOrBroadcastingOrElectronicServices",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LowStockActivity",
                schema: "product",
                table: "Product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManageInventoryMethod",
                schema: "product",
                table: "Product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerPartNumber",
                schema: "product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "MarkAsNew",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "MarkAsNewEndDateTimeUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MarkAsNewStartDateTimeUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaximumCustomerEnteredPrice",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MinStockQuantity",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumCustomerEnteredPrice",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NotApprovedRatingSum",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotApprovedTotalReviews",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NotReturnable",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NotifyAdminForQuantityBelow",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OldPrice",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OrderMaximumQuantity",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderMinimumQuantity",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OverriddenGiftCardAmount",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentGroupedProductId",
                schema: "product",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreOrderAvailabilityStartDateTimeUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductAvailabilityRangeId",
                schema: "product",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "ProductCost",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RentalPriceLength",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RentalPricePeriod",
                schema: "product",
                table: "Product",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                schema: "product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ShipSeparately",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomepage",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                schema: "product",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxCategoryId",
                schema: "product",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "UseMultipleWarehouses",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "VendorId",
                schema: "product",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "VisibleIndividually",
                schema: "product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                schema: "product",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStore",
                schema: "identity",
                table: "UserStore",
                columns: new[] { "StoreId", "UserId" });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "directory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowsBilling = table.Column<bool>(type: "bit", nullable: false),
                    AllowsShipping = table.Column<bool>(type: "bit", nullable: false),
                    TwoLetterIsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThreeLetterIsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumericIsoCode = table.Column<int>(type: "int", nullable: false),
                    SubjectToVat = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDate",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryDate__Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryDate_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAvailabilityRange",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAvailabilityRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAvailabilityRange__Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductAvailabilityRange_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxCategory",
                schema: "tax",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutAttribute",
                schema: "directory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutAttribute_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "directory",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutAttribute",
                schema: "attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextPrompt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    ShippableProductRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxExempt = table.Column<bool>(type: "bit", nullable: false),
                    TaxCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeControlType = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ValidationMinLength = table.Column<int>(type: "int", nullable: true),
                    ValidationMaxLength = table.Column<int>(type: "int", nullable: true),
                    ValidationFileAllowedExtensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidationFileMaximumSize = table.Column<int>(type: "int", nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutAttribute_CheckoutAttribute_ConditionAttributeId",
                        column: x => x.ConditionAttributeId,
                        principalSchema: "attribute",
                        principalTable: "CheckoutAttribute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CheckoutAttribute_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutAttribute_TaxCategory_TaxCategoryId",
                        column: x => x.TaxCategoryId,
                        principalSchema: "tax",
                        principalTable: "TaxCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomAttributes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_CheckoutAttribute_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalSchema: "directory",
                        principalTable: "CheckoutAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "directory",
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CheckoutAttributeValue",
                schema: "attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckoutAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorSquaresRgb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPreSelected = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutAttributeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutAttributeValue_CheckoutAttribute_CheckoutAttributeId",
                        column: x => x.CheckoutAttributeId,
                        principalSchema: "attribute",
                        principalTable: "CheckoutAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    PageSize = table.Column<int>(type: "int", nullable: false),
                    AllowCustomersToSelectPageSize = table.Column<bool>(type: "bit", nullable: false),
                    PageSizeOptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRangeFiltering = table.Column<bool>(type: "bit", nullable: false),
                    PriceFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManuallyPriceRange = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendor_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "common",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                schema: "shipping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "common",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Warehouse_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutAttributeValueLang",
                schema: "attribute",
                columns: table => new
                {
                    CheckoutAttributeValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutAttributeValueLang", x => new { x.CheckoutAttributeValueId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CheckoutAttributeValueLang__Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutAttributeValueLang_CheckoutAttributeValue_CheckoutAttributeValueId",
                        column: x => x.CheckoutAttributeValueId,
                        principalSchema: "attribute",
                        principalTable: "CheckoutAttributeValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorLang",
                columns: table => new
                {
                    VendorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorLang", x => new { x.VendorId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_VendorLang__Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorLang_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWarehouseInventory",
                schema: "product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ReservedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarehouseInventory", x => new { x.ProductId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_ProductWarehouseInventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWarehouseInventory_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "shipping",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_DeliveryDateId",
                schema: "product",
                table: "Product",
                column: "DeliveryDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ParentGroupedProductId",
                schema: "product",
                table: "Product",
                column: "ParentGroupedProductId",
                unique: true,
                filter: "[ParentGroupedProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductAvailabilityRangeId",
                schema: "product",
                table: "Product",
                column: "ProductAvailabilityRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TaxCategoryId",
                schema: "product",
                table: "Product",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_VendorId",
                schema: "product",
                table: "Product",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                schema: "common",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Id",
                schema: "common",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvinceId",
                schema: "common",
                table: "Address",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttribute_ConditionAttributeId",
                schema: "attribute",
                table: "CheckoutAttribute",
                column: "ConditionAttributeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttribute_Id1",
                schema: "attribute",
                table: "CheckoutAttribute",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttribute_StoreId",
                schema: "attribute",
                table: "CheckoutAttribute",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttribute_TaxCategoryId",
                schema: "attribute",
                table: "CheckoutAttribute",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttribute_CountryId",
                schema: "directory",
                table: "CheckoutAttribute",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttribute_Id",
                schema: "directory",
                table: "CheckoutAttribute",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttributeValue_CheckoutAttributeId",
                schema: "attribute",
                table: "CheckoutAttributeValue",
                column: "CheckoutAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttributeValue_Id",
                schema: "attribute",
                table: "CheckoutAttributeValue",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttributeValueLang_LanguageId",
                schema: "attribute",
                table: "CheckoutAttributeValueLang",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Id",
                schema: "directory",
                table: "Country",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDate_Id",
                schema: "shipping",
                table: "DeliveryDate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDate_LanguageId",
                schema: "shipping",
                table: "DeliveryDate",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDate_StoreId",
                schema: "shipping",
                table: "DeliveryDate",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailabilityRange_Id",
                schema: "shipping",
                table: "ProductAvailabilityRange",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailabilityRange_LanguageId",
                schema: "shipping",
                table: "ProductAvailabilityRange",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailabilityRange_StoreId",
                schema: "shipping",
                table: "ProductAvailabilityRange",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarehouseInventory_WarehouseId",
                schema: "product",
                table: "ProductWarehouseInventory",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxCategory_Id",
                schema: "tax",
                table: "TaxCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_AddressId",
                table: "Vendor",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_Id",
                table: "Vendor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VendorLang_LanguageId",
                table: "VendorLang",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_AddressId",
                schema: "shipping",
                table: "Warehouse",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_Id",
                schema: "shipping",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_StoreId",
                schema: "shipping",
                table: "Warehouse",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_DeliveryDate_DeliveryDateId",
                schema: "product",
                table: "Product",
                column: "DeliveryDateId",
                principalSchema: "shipping",
                principalTable: "DeliveryDate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_ParentGroupedProductId",
                schema: "product",
                table: "Product",
                column: "ParentGroupedProductId",
                principalSchema: "product",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductAvailabilityRange_ProductAvailabilityRangeId",
                schema: "product",
                table: "Product",
                column: "ProductAvailabilityRangeId",
                principalSchema: "shipping",
                principalTable: "ProductAvailabilityRange",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TaxCategory_TaxCategoryId",
                schema: "product",
                table: "Product",
                column: "TaxCategoryId",
                principalSchema: "tax",
                principalTable: "TaxCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Vendor_VendorId",
                schema: "product",
                table: "Product",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStore_Store_StoreId",
                schema: "identity",
                table: "UserStore",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStore_Users_UserId",
                schema: "identity",
                table: "UserStore",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_DeliveryDate_DeliveryDateId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_ParentGroupedProductId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductAvailabilityRange_ProductAvailabilityRangeId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_TaxCategory_TaxCategoryId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Vendor_VendorId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStore_Store_StoreId",
                schema: "identity",
                table: "UserStore");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStore_Users_UserId",
                schema: "identity",
                table: "UserStore");

            migrationBuilder.DropTable(
                name: "CheckoutAttributeValueLang",
                schema: "attribute");

            migrationBuilder.DropTable(
                name: "DeliveryDate",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "ProductAvailabilityRange",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "ProductWarehouseInventory",
                schema: "product");

            migrationBuilder.DropTable(
                name: "VendorLang");

            migrationBuilder.DropTable(
                name: "CheckoutAttributeValue",
                schema: "attribute");

            migrationBuilder.DropTable(
                name: "Warehouse",
                schema: "shipping");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "CheckoutAttribute",
                schema: "attribute");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "common");

            migrationBuilder.DropTable(
                name: "TaxCategory",
                schema: "tax");

            migrationBuilder.DropTable(
                name: "CheckoutAttribute",
                schema: "directory");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "directory");

            migrationBuilder.DropIndex(
                name: "IX_Product_DeliveryDateId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ParentGroupedProductId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductAvailabilityRangeId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_TaxCategoryId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_VendorId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStore",
                schema: "identity",
                table: "UserStore");

            migrationBuilder.DropColumn(
                name: "AdditionalShippingCharge",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AdminComment",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AllowAddingOnlyExistingAttributeCombinations",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AllowBackInStockSubscriptions",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AllowCustomerReviews",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AllowedQuantities",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApprovedRatingSum",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApprovedTotalReviews",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AvailableEndDateTimeUtc",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AvailableForPreOrder",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AvailableStartDateTimeUtc",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BackorderMode",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CallForPrice",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CustomerEntersPrice",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeliveryDateId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DisableBuyButton",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DisableWishlistButton",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DisplayStockAvailability",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DisplayStockQuantity",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "GTIN",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "GiftCardType",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "HasDiscountsApplied",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "HasTierPrices",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Height",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsFreeShipping",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsGiftCard",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsRental",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsShipEnabled",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsTaxExempt",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsTelecommunicationsOrBroadcastingOrElectronicServices",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Length",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LowStockActivity",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ManageInventoryMethod",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ManufacturerPartNumber",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MarkAsNew",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MarkAsNewEndDateTimeUtc",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MarkAsNewStartDateTimeUtc",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MaximumCustomerEnteredPrice",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MinStockQuantity",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MinimumCustomerEnteredPrice",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NotApprovedRatingSum",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NotApprovedTotalReviews",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NotReturnable",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NotifyAdminForQuantityBelow",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderMaximumQuantity",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderMinimumQuantity",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OverriddenGiftCardAmount",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ParentGroupedProductId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PreOrderAvailabilityStartDateTimeUtc",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductAvailabilityRangeId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductCost",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductType",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Published",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RentalPriceLength",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RentalPricePeriod",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SKU",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShipSeparately",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShowOnHomepage",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TaxCategoryId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UseMultipleWarehouses",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VendorId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VisibleIndividually",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Width",
                schema: "product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "UserStore",
                schema: "identity",
                newName: "UserStoreEntity");

            migrationBuilder.RenameIndex(
                name: "IX_UserStore_UserId",
                table: "UserStoreEntity",
                newName: "IX_UserStoreEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStoreEntity",
                table: "UserStoreEntity",
                columns: new[] { "StoreId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoreEntity_Store_StoreId",
                table: "UserStoreEntity",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoreEntity_Users_UserId",
                table: "UserStoreEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
