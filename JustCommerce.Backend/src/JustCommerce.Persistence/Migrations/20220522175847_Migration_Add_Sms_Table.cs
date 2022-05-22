using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Sms_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategoryLang__Language_LanguageId",
                table: "ArticleCategoryLang");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleLang__Language_LanguageId",
                table: "ArticleLang");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentMethodLangEntity__Language_LangaugeId",
                table: "ShipmentMethodLangEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Language",
                table: "_Language");

            migrationBuilder.RenameTable(
                name: "_Language",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "SmtpProt",
                table: "EmailAccount",
                newName: "SmtpPort");

            migrationBuilder.RenameColumn(
                name: "Pop3Prot",
                table: "EmailAccount",
                newName: "Pop3Port");

            migrationBuilder.RenameIndex(
                name: "IX__Language_Id",
                table: "Language",
                newName: "IX_Language_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shop",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShipmentMethod",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductTypeProperty",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductType",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmailTemplate",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EmailTemplate",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmailAccount",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EmailAccount",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Language",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<bool>(
                name: "Defualt",
                table: "Language",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    TradeCreditDays = table.Column<int>(type: "int", nullable: true),
                    PaymentReminderSend = table.Column<bool>(type: "bit", nullable: false),
                    SmsNotification = table.Column<bool>(type: "bit", nullable: false),
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
                        name: "FK_Order_Language_LanguageVersionId",
                        column: x => x.LanguageVersionId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_ShipmentMethod_ShipmentMethodId",
                        column: x => x.ShipmentMethodId,
                        principalTable: "ShipmentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SmsAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SmsGate = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    From = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Token = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Test = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsAccount_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmailAccount",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EmailAddress", "ImapLogin", "ImapPassword", "ImapPort", "ImapServer", "LastModifiedBy", "LastModifiedDate", "Name", "Pop3Login", "Pop3Password", "Pop3Port", "Pop3Server", "ShopId", "SmtpLogin", "SmtpPassword", "SmtpPort", "SmtpServer" },
                values: new object[] { new Guid("014e3b4b-e2a7-4499-8c82-a905b7b086e2"), null, null, "kontakt@emagazynowo.pl", "kontakt@emagazynowo.pl", "kaHBV(.q4F", "143", "serwer2299342.home.pl", null, null, "Ogolne", null, "", "1", "", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"), "", "", "1", "" });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                columns: new[] { "CreatedDate", "Defualt" },
                values: new object[] { null, true });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.InsertData(
                table: "SmsAccount",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "From", "LastModifiedBy", "LastModifiedDate", "ShopId", "SmsGate", "Test", "Token" },
                values: new object[] { new Guid("2bbfc7c9-8c9c-4f53-82ef-f7560a463070"), null, null, "Test", null, null, new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"), "SmsApi", false, "te" });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedDate", "Email", "EmailAccountId", "EmailName", "EmailType", "FilePath", "LastModifiedBy", "LastModifiedDate", "Name", "ShopId", "Subject" },
                values: new object[] { new Guid("cf702e9b-cceb-476f-ba6e-455004ebf588"), true, null, null, "kontakt@emagazynowo.pl", new Guid("014e3b4b-e2a7-4499-8c82-a905b7b086e2"), "eMagazynowo", "ConfirmAccount", "D:\\Projects\\JustCommerce\\JustCommerce.Backend\\src\\JustCommerce.Api\\Templates\\EmailTemplates\\6cef7328-534d-4699-98af-8779fba7d3a1\\EmailConfirmation.html", null, null, "EmailConfirmed", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"), "eMagazynowo : Potwierdzenie rejestracji" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_LanguageVersionId",
                table: "Order",
                column: "LanguageVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderNumber",
                table: "Order",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShipmentMethodId",
                table: "Order",
                column: "ShipmentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShopId",
                table: "Order",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsAccount_Id",
                table: "SmsAccount",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SmsAccount_ShopId",
                table: "SmsAccount",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategoryLang_Language_LanguageId",
                table: "ArticleCategoryLang",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleLang_Language_LanguageId",
                table: "ArticleLang",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentMethodLangEntity_Language_LangaugeId",
                table: "ShipmentMethodLangEntity",
                column: "LangaugeId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategoryLang_Language_LanguageId",
                table: "ArticleCategoryLang");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleLang_Language_LanguageId",
                table: "ArticleLang");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentMethodLangEntity_Language_LangaugeId",
                table: "ShipmentMethodLangEntity");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "SmsAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DeleteData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: new Guid("cf702e9b-cceb-476f-ba6e-455004ebf588"));

            migrationBuilder.DeleteData(
                table: "EmailAccount",
                keyColumn: "Id",
                keyValue: new Guid("014e3b4b-e2a7-4499-8c82-a905b7b086e2"));

            migrationBuilder.DropColumn(
                name: "Defualt",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "_Language");

            migrationBuilder.RenameColumn(
                name: "SmtpPort",
                table: "EmailAccount",
                newName: "SmtpProt");

            migrationBuilder.RenameColumn(
                name: "Pop3Port",
                table: "EmailAccount",
                newName: "Pop3Prot");

            migrationBuilder.RenameIndex(
                name: "IX_Language_Id",
                table: "_Language",
                newName: "IX__Language_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Shop",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShipmentMethod",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductTypeProperty",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductType",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmailTemplate",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EmailTemplate",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EmailAccount",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EmailAccount",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "_Language",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Language",
                table: "_Language",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 13, 45, 9, 609, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 13, 45, 9, 609, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 13, 45, 9, 609, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 13, 45, 9, 609, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 13, 45, 9, 652, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 13, 45, 9, 652, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 13, 45, 9, 556, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 13, 13, 45, 9, 551, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategoryLang__Language_LanguageId",
                table: "ArticleCategoryLang",
                column: "LanguageId",
                principalTable: "_Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleLang__Language_LanguageId",
                table: "ArticleLang",
                column: "LanguageId",
                principalTable: "_Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentMethodLangEntity__Language_LangaugeId",
                table: "ShipmentMethodLangEntity",
                column: "LangaugeId",
                principalTable: "_Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
