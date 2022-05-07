using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Shop_Id_To_Offer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IampServer",
                table: "EmailAccount",
                newName: "ImapServer");

            migrationBuilder.RenameColumn(
                name: "IampProt",
                table: "EmailAccount",
                newName: "ImapPort");

            migrationBuilder.RenameColumn(
                name: "IampPassword",
                table: "EmailAccount",
                newName: "ImapPassword");

            migrationBuilder.RenameColumn(
                name: "IampLogin",
                table: "EmailAccount",
                newName: "ImapLogin");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Offer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "EmailTemplate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 7, 18, 47, 58, 611, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 7, 18, 47, 58, 611, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 7, 18, 47, 58, 611, DateTimeKind.Local).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 7, 18, 47, 58, 611, DateTimeKind.Local).AddTicks(6448));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 7, 18, 47, 58, 638, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 7, 18, 47, 58, 638, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 7, 18, 47, 58, 547, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 7, 18, 47, 58, 542, DateTimeKind.Local).AddTicks(9582));

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ShopId",
                table: "Offer",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplate_ShopId",
                table: "EmailTemplate",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplate_Shop_ShopId",
                table: "EmailTemplate",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Shop_ShopId",
                table: "Offer",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplate_Shop_ShopId",
                table: "EmailTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Shop_ShopId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_ShopId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_EmailTemplate_ShopId",
                table: "EmailTemplate");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "EmailTemplate");

            migrationBuilder.RenameColumn(
                name: "ImapServer",
                table: "EmailAccount",
                newName: "IampServer");

            migrationBuilder.RenameColumn(
                name: "ImapPort",
                table: "EmailAccount",
                newName: "IampProt");

            migrationBuilder.RenameColumn(
                name: "ImapPassword",
                table: "EmailAccount",
                newName: "IampPassword");

            migrationBuilder.RenameColumn(
                name: "ImapLogin",
                table: "EmailAccount",
                newName: "IampLogin");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 12, 21, 3, 975, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 12, 21, 3, 975, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 12, 21, 3, 975, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 12, 21, 3, 975, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 12, 21, 3, 991, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 12, 21, 3, 991, DateTimeKind.Local).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 12, 21, 3, 928, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 6, 12, 21, 3, 924, DateTimeKind.Local).AddTicks(8825));
        }
    }
}
