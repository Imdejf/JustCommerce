using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Seed_For_Shop_And_Language : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageEntity",
                table: "LanguageEntity");

            migrationBuilder.RenameTable(
                name: "LanguageEntity",
                newName: "_Language");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageEntity_Id",
                table: "_Language",
                newName: "IX__Language_Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "_Language",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Language",
                table: "_Language",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "Id", "Active", "AddressLine", "City", "Country", "CreatedBy", "CreatedDate", "Email", "FullName", "LastModifiedBy", "LastModifiedDate", "Name", "State", "Zip" },
                values: new object[,]
                {
                    { new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"), true, "Polna 7", "Przytoczna", "Poland", null, new DateTime(2022, 4, 26, 21, 39, 8, 3, DateTimeKind.Local).AddTicks(1737), "kontakt@emagazynowo.pl", "eMagazynowo Dawid Jabłoński", null, null, "eMagazynowo", "Lubuskie", "66-340" },
                    { new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"), true, "Karpia 22F/59", "Poznan", "Poland", null, new DateTime(2022, 4, 26, 21, 39, 8, 3, DateTimeKind.Local).AddTicks(1589), "jablonskidawid0202@gmail.com", "Data-Sharp Dawid Jabłoński", null, null, "DataSharp", "Wielkopolska", "61-619" }
                });

            migrationBuilder.InsertData(
                table: "_Language",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsoCode", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"), null, new DateTime(2022, 4, 26, 21, 39, 7, 961, DateTimeKind.Local).AddTicks(5033), "EN-en", null, null, "English" },
                    { new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"), null, new DateTime(2022, 4, 26, 21, 39, 7, 957, DateTimeKind.Local).AddTicks(2546), "PL-pl", null, null, "Poland" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Language",
                table: "_Language");

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"));

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"));

            migrationBuilder.DeleteData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"));

            migrationBuilder.DeleteData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"));

            migrationBuilder.RenameTable(
                name: "_Language",
                newName: "LanguageEntity");

            migrationBuilder.RenameIndex(
                name: "IX__Language_Id",
                table: "LanguageEntity",
                newName: "IX_LanguageEntity_Id");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "LanguageEntity",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageEntity",
                table: "LanguageEntity",
                column: "Id");
        }
    }
}
