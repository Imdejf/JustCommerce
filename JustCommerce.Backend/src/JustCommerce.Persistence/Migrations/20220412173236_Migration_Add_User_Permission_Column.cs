using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_User_Permission_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Shop_ShopId",
                schema: "identity",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "identity",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "identity",
                newName: "User",
                newSchema: "identity");

            migrationBuilder.RenameIndex(
                name: "IX_users_ShopId",
                schema: "identity",
                table: "User",
                newName: "IX_User_ShopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "identity",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserPermission",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionDomainName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PermissionFlagValue = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => new { x.PermissionDomainName, x.PermissionFlagValue, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPermission_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_UserId",
                schema: "identity",
                table: "UserPermission",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "UserPermission",
                schema: "identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "identity",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "identity",
                newName: "users",
                newSchema: "identity");

            migrationBuilder.RenameIndex(
                name: "IX_User_ShopId",
                schema: "identity",
                table: "users",
                newName: "IX_users_ShopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "identity",
                table: "users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Shop_ShopId",
                schema: "identity",
                table: "users",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
