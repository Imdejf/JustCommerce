using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Product_Type_Property_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypeProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderValue = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypeProperty_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypePropertyLang",
                columns: table => new
                {
                    ProductTypePropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefualtValue = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    IsoCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypePropertyLang", x => x.ProductTypePropertyId);
                    table.ForeignKey(
                        name: "FK_ProductTypePropertyLang_ProductTypeProperty_ProductTypePropertyId",
                        column: x => x.ProductTypePropertyId,
                        principalTable: "ProductTypeProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeProperty_ProductTypeId",
                table: "ProductTypeProperty",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTypePropertyLang");

            migrationBuilder.DropTable(
                name: "ProductTypeProperty");
        }
    }
}
