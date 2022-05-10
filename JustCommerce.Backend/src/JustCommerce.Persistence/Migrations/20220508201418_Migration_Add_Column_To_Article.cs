using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Column_To_Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "ArticleCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Article",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 22, 14, 16, 56, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 22, 14, 16, 56, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 22, 14, 16, 56, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 22, 14, 16, 56, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 22, 14, 16, 74, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 22, 14, 16, 74, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 22, 14, 16, 17, DateTimeKind.Local).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 22, 14, 16, 14, DateTimeKind.Local).AddTicks(4097));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_ShopId",
                table: "ArticleCategory",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_ShopId",
                table: "Article",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Shop_ShopId",
                table: "Article",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Shop_ShopId",
                table: "ArticleCategory",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Shop_ShopId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Shop_ShopId",
                table: "ArticleCategory");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCategory_ShopId",
                table: "ArticleCategory");

            migrationBuilder.DropIndex(
                name: "IX_Article_ShopId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "ArticleCategory");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Article");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 450, DateTimeKind.Local).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 450, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 450, DateTimeKind.Local).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 450, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 473, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 473, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 403, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 398, DateTimeKind.Local).AddTicks(9947));
        }
    }
}
