using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Change_In_Identity_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Shop_ShopId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ShopId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ShopId",
                schema: "identity",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Shop",
                newName: "IsActive");

            migrationBuilder.AddColumn<string>(
                name: "FtpPhotoFilePath",
                schema: "identity",
                table: "User",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                schema: "identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Profile",
                schema: "identity",
                table: "User",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SelectedShopId",
                schema: "identity",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                schema: "identity",
                table: "User",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserShop",
                schema: "common",
                columns: table => new
                {
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShop", x => new { x.UserId, x.ShopId });
                    table.ForeignKey(
                        name: "FK_UserShop_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserShop_User_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "IsActive",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserShop_ShopId",
                schema: "common",
                table: "UserShop",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserShop",
                schema: "common");

            migrationBuilder.DropColumn(
                name: "FtpPhotoFilePath",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Language",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Profile",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SelectedShopId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Theme",
                schema: "identity",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Shop",
                newName: "Active");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                schema: "identity",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "Active",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ShopId",
                schema: "identity",
                table: "User",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Shop_ShopId",
                schema: "identity",
                table: "User",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id");
        }
    }
}
