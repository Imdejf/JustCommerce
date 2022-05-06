using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Offer_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CustomerEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CustomerPhone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    InvoiceRecipientName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientTaxId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientCountry = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRcipientCity = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientPostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    InvoiceRecipientAdress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    DiffrentShipmentRecipient = table.Column<bool>(type: "bit", nullable: false),
                    ShipmentRecipientName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ShipmentRecipientCountry = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ShipmentRecipientCity = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ShipmentRecipientPostalCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ShipmentRecipientAdress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AdditionalInfo = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    Note = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    OfferStatusType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CompletionTime = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PaymentType = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    TotallPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    ShipmentPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    ItemSumPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    EInvoice = table.Column<bool>(type: "bit", nullable: false),
                    OfferSource = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SendToClientDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferItem",
                columns: table => new
                {
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSellableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NettoPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    ProducentPrice = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItem", x => new { x.OfferId, x.ProductSellableId });
                    table.ForeignKey(
                        name: "FK_OfferItem_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferItem_ProductSellable_ProductSellableId",
                        column: x => x.ProductSellableId,
                        principalTable: "ProductSellable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 11, 38, 4, 871, DateTimeKind.Local).AddTicks(5273));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 11, 38, 4, 871, DateTimeKind.Local).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 11, 38, 4, 871, DateTimeKind.Local).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 11, 38, 4, 871, DateTimeKind.Local).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 11, 38, 4, 881, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 11, 38, 4, 881, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 11, 38, 4, 825, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 11, 38, 4, 822, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.CreateIndex(
                name: "IX_Offer_Id_OfferNumber",
                table: "Offer",
                columns: new[] { "Id", "OfferNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_ProductSellableId",
                table: "OfferItem",
                column: "ProductSellableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferItem");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 33, 39, 417, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 33, 39, 417, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 33, 39, 417, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 33, 39, 417, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 33, 39, 438, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 33, 39, 438, DateTimeKind.Local).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 33, 39, 371, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 33, 39, 364, DateTimeKind.Local).AddTicks(58));
        }
    }
}
