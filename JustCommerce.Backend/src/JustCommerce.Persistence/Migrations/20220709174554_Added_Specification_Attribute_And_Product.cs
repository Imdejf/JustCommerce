using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Added_Specification_Attribute_And_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "attribute");

            migrationBuilder.RenameTable(
                name: "ProductAttributeLang",
                schema: "product",
                newName: "ProductAttributeLang",
                newSchema: "attribute");

            migrationBuilder.RenameTable(
                name: "ProductAttribute",
                schema: "product",
                newName: "ProductAttribute",
                newSchema: "attribute");

            migrationBuilder.RenameTable(
                name: "PredefinedProductAttributeValueLang",
                schema: "product",
                newName: "PredefinedProductAttributeValueLang",
                newSchema: "attribute");

            migrationBuilder.RenameTable(
                name: "PredefinedProductAttributeValue",
                schema: "product",
                newName: "PredefinedProductAttributeValue",
                newSchema: "attribute");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationAttributeGroup",
                schema: "attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationAttributeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationAttributeGroup_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationAttribute",
                schema: "attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    SpecificationAttributeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationAttribute_SpecificationAttributeGroup_SpecificationAttributeGroupId",
                        column: x => x.SpecificationAttributeGroupId,
                        principalSchema: "attribute",
                        principalTable: "SpecificationAttributeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationAttributeOption",
                schema: "attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecificationAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorSquaresRgb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationAttributeOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationAttributeOption_SpecificationAttribute_SpecificationAttributeId",
                        column: x => x.SpecificationAttributeId,
                        principalSchema: "attribute",
                        principalTable: "SpecificationAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecificationAttribute",
                schema: "attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecificationAttributeType = table.Column<int>(type: "int", nullable: false),
                    SpecificationAttributeOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowFiltering = table.Column<bool>(type: "bit", nullable: false),
                    ShowOnProductPage = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecificationAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationAttribute_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationAttribute_SpecificationAttributeOption_SpecificationAttributeOptionId",
                        column: x => x.SpecificationAttributeOptionId,
                        principalSchema: "attribute",
                        principalTable: "SpecificationAttributeOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationAttributeOptionLang",
                schema: "attribute",
                columns: table => new
                {
                    SpecificationAttributeOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationAttributeOptionLang", x => new { x.LanguageId, x.SpecificationAttributeOptionId });
                    table.ForeignKey(
                        name: "FK_SpecificationAttributeOptionLang__Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificationAttributeOptionLang_SpecificationAttributeOption_SpecificationAttributeOptionId",
                        column: x => x.SpecificationAttributeOptionId,
                        principalSchema: "attribute",
                        principalTable: "SpecificationAttributeOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                schema: "product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationAttribute_Id",
                schema: "attribute",
                table: "ProductSpecificationAttribute",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationAttribute_ProductId",
                schema: "attribute",
                table: "ProductSpecificationAttribute",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationAttribute_SpecificationAttributeOptionId",
                schema: "attribute",
                table: "ProductSpecificationAttribute",
                column: "SpecificationAttributeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttribute_Id",
                schema: "attribute",
                table: "SpecificationAttribute",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttribute_SpecificationAttributeGroupId",
                schema: "attribute",
                table: "SpecificationAttribute",
                column: "SpecificationAttributeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttributeGroup_Id",
                schema: "attribute",
                table: "SpecificationAttributeGroup",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttributeGroup_StoreId",
                schema: "attribute",
                table: "SpecificationAttributeGroup",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttributeOption_Id",
                schema: "attribute",
                table: "SpecificationAttributeOption",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttributeOption_SpecificationAttributeId",
                schema: "attribute",
                table: "SpecificationAttributeOption",
                column: "SpecificationAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttributeOptionLang_SpecificationAttributeOptionId",
                schema: "attribute",
                table: "SpecificationAttributeOptionLang",
                column: "SpecificationAttributeOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSpecificationAttribute",
                schema: "attribute");

            migrationBuilder.DropTable(
                name: "SpecificationAttributeOptionLang",
                schema: "attribute");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "product");

            migrationBuilder.DropTable(
                name: "SpecificationAttributeOption",
                schema: "attribute");

            migrationBuilder.DropTable(
                name: "SpecificationAttribute",
                schema: "attribute");

            migrationBuilder.DropTable(
                name: "SpecificationAttributeGroup",
                schema: "attribute");

            migrationBuilder.RenameTable(
                name: "ProductAttributeLang",
                schema: "attribute",
                newName: "ProductAttributeLang",
                newSchema: "product");

            migrationBuilder.RenameTable(
                name: "ProductAttribute",
                schema: "attribute",
                newName: "ProductAttribute",
                newSchema: "product");

            migrationBuilder.RenameTable(
                name: "PredefinedProductAttributeValueLang",
                schema: "attribute",
                newName: "PredefinedProductAttributeValueLang",
                newSchema: "product");

            migrationBuilder.RenameTable(
                name: "PredefinedProductAttributeValue",
                schema: "attribute",
                newName: "PredefinedProductAttributeValue",
                newSchema: "product");
        }
    }
}
