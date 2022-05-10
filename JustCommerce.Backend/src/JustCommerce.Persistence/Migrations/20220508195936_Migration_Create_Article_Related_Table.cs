using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Create_Article_Related_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategoryRelated",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategoryRelated", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ArticleCategoryRelated_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategoryRelated_ArticleCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ArticleCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleRelatedProduct",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleRelatedProduct", x => new { x.ProductId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleRelatedProduct_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleRelatedProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 450, DateTimeKind.Local).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 450, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 450, DateTimeKind.Local).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 450, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 473, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 473, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 403, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 21, 59, 34, 398, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategoryRelated_CategoryId",
                table: "ArticleCategoryRelated",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleRelatedProduct_ArticleId",
                table: "ArticleRelatedProduct",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategoryRelated");

            migrationBuilder.DropTable(
                name: "ArticleRelatedProduct");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 20, 58, 58, 172, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 20, 58, 58, 172, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 20, 58, 58, 172, DateTimeKind.Local).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 20, 58, 58, 172, DateTimeKind.Local).AddTicks(8814));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 20, 58, 58, 194, DateTimeKind.Local).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 20, 58, 58, 194, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 20, 58, 58, 125, DateTimeKind.Local).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 8, 20, 58, 58, 120, DateTimeKind.Local).AddTicks(801));
        }
    }
}
