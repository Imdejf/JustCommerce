using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class AddedProductTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecificationAttributeType",
                schema: "attribute",
                table: "ProductSpecificationAttribute",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AttributeControlType",
                schema: "attribute",
                table: "CheckoutAttribute",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ProductTag",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTag_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductTag",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProductTag_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductTag_ProductTag_ProductTagId",
                        column: x => x.ProductTagId,
                        principalSchema: "product",
                        principalTable: "ProductTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTagLang",
                schema: "product",
                columns: table => new
                {
                    ProductTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTagLang", x => new { x.LanguageId, x.ProductTagId });
                    table.ForeignKey(
                        name: "FK_ProductTagLang__Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTagLang_ProductTag_ProductTagId",
                        column: x => x.ProductTagId,
                        principalSchema: "product",
                        principalTable: "ProductTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductTag_Id",
                schema: "product",
                table: "ProductProductTag",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductTag_ProductId",
                schema: "product",
                table: "ProductProductTag",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductTag_ProductTagId",
                schema: "product",
                table: "ProductProductTag",
                column: "ProductTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_Id",
                schema: "product",
                table: "ProductTag",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_StoreId",
                schema: "product",
                table: "ProductTag",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTagLang_ProductTagId",
                schema: "product",
                table: "ProductTagLang",
                column: "ProductTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductTag",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductTagLang",
                schema: "product");

            migrationBuilder.DropTable(
                name: "ProductTag",
                schema: "product");

            migrationBuilder.AlterColumn<int>(
                name: "SpecificationAttributeType",
                schema: "attribute",
                table: "ProductSpecificationAttribute",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "AttributeControlType",
                schema: "attribute",
                table: "CheckoutAttribute",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
