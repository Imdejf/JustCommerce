using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Order_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CustomerEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CustomerPhone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipeintName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientTax = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientCountry = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientRegion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientCity = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientPostalCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    InvoiceRecipientAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    DifferentShipmentRecipient = table.Column<bool>(type: "bit", nullable: false),
                    ShipmentRecipientName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ShipmentRecipientCountry = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ShipmentRecipientRegion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ShipmentRecipientCity = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ShipmentRecipientPostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ShipmentRecipientAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    TotallPriceGross = table.Column<decimal>(type: "decimal", nullable: false),
                    ShipmentPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    ItemsSumPriceGross = table.Column<decimal>(type: "decimal", nullable: false),
                    PaymentsSum = table.Column<decimal>(type: "decimal", nullable: false),
                    ShipmentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    InvoiceNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ProformaNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    OrderPdf = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Invoice = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    LanguageVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsletterAcceptation = table.Column<bool>(type: "bit", nullable: false),
                    StatueAcceptation = table.Column<bool>(type: "bit", nullable: false),
                    DataProcessingAcceptation = table.Column<bool>(type: "bit", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    FastInvoice = table.Column<bool>(type: "bit", nullable: false),
                    PaymentCallSent = table.Column<bool>(type: "bit", nullable: false),
                    IncludeShipmentRecipientOnInvoice = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    TradeCreditDays = table.Column<int>(type: "int", nullable: false),
                    PaymentReminderSend = table.Column<bool>(type: "bit", nullable: false),
                    Source = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Rated = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order__Language_LanguageVersionId",
                        column: x => x.LanguageVersionId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_ShipmentMethod_ShipmentMethodId",
                        column: x => x.ShipmentMethodId,
                        principalTable: "ShipmentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 18, 21, 44, 51, 722, DateTimeKind.Local).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 18, 21, 44, 51, 722, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 18, 21, 44, 51, 722, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 18, 21, 44, 51, 722, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 18, 21, 44, 51, 742, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 18, 21, 44, 51, 742, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 18, 21, 44, 51, 635, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 18, 21, 44, 51, 631, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.CreateIndex(
                name: "IX_Order_Id",
                table: "Order",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_LanguageVersionId",
                table: "Order",
                column: "LanguageVersionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShipmentMethodId",
                table: "Order",
                column: "ShipmentMethodId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 12, 3, 23, 858, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 12, 3, 23, 858, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 12, 3, 23, 858, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 12, 3, 23, 858, DateTimeKind.Local).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 12, 3, 23, 875, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 12, 3, 23, 875, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 12, 3, 23, 821, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 16, 12, 3, 23, 817, DateTimeKind.Local).AddTicks(6543));
        }
    }
}
