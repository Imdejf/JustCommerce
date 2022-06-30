using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_New_Column_To_Shop_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Language",
                newName: "NameOrginal");

            migrationBuilder.RenameColumn(
                name: "Defualt",
                table: "Language",
                newName: "IsActive");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DefaultLanguage",
                table: "Language",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NameInternational",
                table: "Language",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Language",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "_Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_UserNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    Seen = table.Column<bool>(type: "bit", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserNotification_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_UserSubscribed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserSubscribed", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserSubscribed_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                columns: new[] { "IsActive", "NameInternational", "ShopId" },
                values: new object[] { true, "English", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1") });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                columns: new[] { "DefaultLanguage", "NameInternational", "NameOrginal", "ShopId" },
                values: new object[] { true, "Polish", "Polski", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1") });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DefaultLanguage", "IsActive", "IsoCode", "LastModifiedBy", "LastModifiedDate", "NameInternational", "NameOrginal", "ShopId" },
                values: new object[,]
                {
                    { new Guid("42f64f81-7935-4724-beb4-edc5f6033868"), null, null, false, true, "EN-en", null, null, "English", "English", new Guid("83e84e94-b1ee-4cbf-be40-daea69347600") },
                    { new Guid("cce919b8-3a08-417f-8eec-cac0b3fa3b31"), null, null, true, true, "PL-pl", null, null, "Polish", "Polski", new Guid("83e84e94-b1ee-4cbf-be40-daea69347600") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Language_ShopId",
                table: "Language",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX__UserNotification_UserId",
                table: "_UserNotification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX__UserSubscribed_UserId",
                table: "_UserSubscribed",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Language_Shop_ShopId",
                table: "Language",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Language_Shop_ShopId",
                table: "Language");

            migrationBuilder.DropTable(
                name: "_Notification");

            migrationBuilder.DropTable(
                name: "_UserNotification");

            migrationBuilder.DropTable(
                name: "_UserSubscribed");

            migrationBuilder.DropIndex(
                name: "IX_Language_ShopId",
                table: "Language");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("42f64f81-7935-4724-beb4-edc5f6033868"));

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("cce919b8-3a08-417f-8eec-cac0b3fa3b31"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "DefaultLanguage",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "NameInternational",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Language");

            migrationBuilder.RenameColumn(
                name: "NameOrginal",
                table: "Language",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Language",
                newName: "Defualt");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "Defualt",
                value: false);

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "Name",
                value: "Poland");
        }
    }
}
