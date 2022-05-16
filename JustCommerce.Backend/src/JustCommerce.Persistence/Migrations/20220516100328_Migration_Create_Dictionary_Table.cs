using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Create_Dictionary_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EmailTemplate",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EmailAccount",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "DictionaryType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DictionaryType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(54)", maxLength: 54, nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryType_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DictionaryTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Dictionary = table.Column<string>(type: "varchar(54)", maxLength: 54, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dictionary_DictionaryType_DictionaryTypeId",
                        column: x => x.DictionaryTypeId,
                        principalTable: "DictionaryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryLang",
                columns: table => new
                {
                    DictionaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryLang", x => new { x.DictionaryId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_DictionaryLang__Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DictionaryLang_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Dictionary_DictionaryTypeId",
                table: "Dictionary",
                column: "DictionaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionary_Id",
                table: "Dictionary",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryLang_LanguageId",
                table: "DictionaryLang",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryType_Id_DictionaryType",
                table: "DictionaryType",
                columns: new[] { "Id", "DictionaryType" });

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryType_ShopId",
                table: "DictionaryType",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictionaryLang");

            migrationBuilder.DropTable(
                name: "Dictionary");

            migrationBuilder.DropTable(
                name: "DictionaryType");

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
        }
    }
}
