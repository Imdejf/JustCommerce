using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Email_And_Shop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "identity");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopEntityId",
                schema: "identity",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    AddressLine = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Zip = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Pop3Server = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Pop3Prot = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Pop3Login = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Pop3Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    SmtpServer = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    SmtpProt = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    SmtpLogin = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    SmtpPassword = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IampServer = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IampProt = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    IampLogin = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IampPassword = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAccount_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    FilePath = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Email = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    EmailName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Actvie = table.Column<bool>(type: "bit", nullable: false),
                    EmailType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailTemplate_EmailAccount_EmailAccountId",
                        column: x => x.EmailAccountId,
                        principalTable: "EmailAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ShopEntityId",
                schema: "identity",
                table: "User",
                column: "ShopEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAccount_ShopId",
                table: "EmailAccount",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplate_EmailAccountId",
                table: "EmailTemplate",
                column: "EmailAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Shop_ShopEntityId",
                schema: "identity",
                table: "User",
                column: "ShopEntityId",
                principalTable: "Shop",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Shop_ShopEntityId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "EmailTemplate");

            migrationBuilder.DropTable(
                name: "EmailAccount");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_User_ShopEntityId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ShopEntityId",
                schema: "identity",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "identity",
                newName: "User");
        }
    }
}
