using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class FixColunInManufacturerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageSizeOptions",
                schema: "product",
                table: "Manufacturer");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                schema: "product",
                table: "Manufacturer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_StoreId",
                schema: "product",
                table: "Manufacturer",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturer_Store_StoreId",
                schema: "product",
                table: "Manufacturer",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturer_Store_StoreId",
                schema: "product",
                table: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturer_StoreId",
                schema: "product",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "StoreId",
                schema: "product",
                table: "Manufacturer");

            migrationBuilder.AddColumn<string>(
                name: "PageSizeOptions",
                schema: "product",
                table: "Manufacturer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
