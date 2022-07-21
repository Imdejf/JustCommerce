using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class FixInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTagLang",
                schema: "product");

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                schema: "product",
                table: "ProductTag",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "product",
                table: "ProductTag",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOnUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                schema: "product",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOnUtc",
                schema: "product",
                table: "Category",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentCategoryId",
                schema: "product",
                table: "Category",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "ProductLang",
                schema: "product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLang", x => new { x.ProductId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ProductLang__Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLang_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedProduct",
                schema: "product",
                columns: table => new
                {
                    Product1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedProduct", x => new { x.Product1Id, x.Product2Id });
                    table.ForeignKey(
                        name: "FK_RelatedProduct_Product_Product1Id",
                        column: x => x.Product1Id,
                        principalSchema: "product",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelatedProduct_Product_Product2Id",
                        column: x => x.Product2Id,
                        principalSchema: "product",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_LanguageId",
                schema: "product",
                table: "ProductTag",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreId",
                schema: "product",
                table: "Product",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLang_LanguageId",
                schema: "product",
                table: "ProductLang",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProduct_Product2Id",
                schema: "product",
                table: "RelatedProduct",
                column: "Product2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Store_StoreId",
                schema: "product",
                table: "Product",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag__Language_LanguageId",
                schema: "product",
                table: "ProductTag",
                column: "LanguageId",
                principalTable: "_Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Store_StoreId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag__Language_LanguageId",
                schema: "product",
                table: "ProductTag");

            migrationBuilder.DropTable(
                name: "ProductLang",
                schema: "product");

            migrationBuilder.DropTable(
                name: "RelatedProduct",
                schema: "product");

            migrationBuilder.DropIndex(
                name: "IX_ProductTag_LanguageId",
                schema: "product",
                table: "ProductTag");

            migrationBuilder.DropIndex(
                name: "IX_Product_StoreId",
                schema: "product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "product",
                table: "ProductTag");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "product",
                table: "ProductTag");

            migrationBuilder.DropColumn(
                name: "StoreId",
                schema: "product",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOnUtc",
                schema: "product",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOnUtc",
                schema: "product",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentCategoryId",
                schema: "product",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProductTagLang",
                schema: "product",
                columns: table => new
                {
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_ProductTagLang_ProductTagId",
                schema: "product",
                table: "ProductTagLang",
                column: "ProductTagId");
        }
    }
}
