using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Shop_Id_To_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Shop_ShopEntityId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ShopEntityId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ShopEntityId",
                schema: "identity",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                schema: "identity",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                schema: "identity",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_ShopId",
                schema: "identity",
                table: "User",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Id",
                table: "Shop",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Shop_ShopId",
                schema: "identity",
                table: "User",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Shop_ShopId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Id",
                schema: "identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ShopId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Shop_Id",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "ShopId",
                schema: "identity",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopEntityId",
                schema: "identity",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ShopEntityId",
                schema: "identity",
                table: "User",
                column: "ShopEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Shop_ShopEntityId",
                schema: "identity",
                table: "User",
                column: "ShopEntityId",
                principalTable: "Shop",
                principalColumn: "Id");
        }
    }
}
