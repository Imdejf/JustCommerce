using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Product_Sellable_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductSellable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    NettoPrice = table.Column<decimal>(type: "decimal", nullable: false, defaultValue: 0m),
                    Tax = table.Column<decimal>(type: "decimal", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "decimal", nullable: false, defaultValue: 0m),
                    OldPrice = table.Column<decimal>(type: "decimal", nullable: false, defaultValue: 0m),
                    ProducentPrice = table.Column<decimal>(type: "decimal", nullable: false, defaultValue: 0m),
                    Weight = table.Column<decimal>(type: "decimal", nullable: false, defaultValue: 0m),
                    ProductNumber = table.Column<string>(type: "varchar", nullable: true),
                    EanCode = table.Column<string>(type: "varchar", nullable: true),
                    IconPath = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSellable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSellable_Product_ProductId",
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
                value: new DateTime(2022, 5, 4, 21, 29, 55, 358, DateTimeKind.Local).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 29, 55, 358, DateTimeKind.Local).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 29, 55, 358, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 29, 55, 358, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 29, 55, 377, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 29, 55, 377, DateTimeKind.Local).AddTicks(6374));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 29, 55, 331, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 5, 4, 21, 29, 55, 327, DateTimeKind.Local).AddTicks(4765));

            migrationBuilder.CreateIndex(
                name: "IX_ProductSellable_Id",
                table: "ProductSellable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSellable_ProductId",
                table: "ProductSellable",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSellable");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 48, 53, 134, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 48, 53, 134, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 48, 53, 134, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 48, 53, 134, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 48, 53, 146, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 48, 53, 146, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 48, 53, 113, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 48, 53, 109, DateTimeKind.Local).AddTicks(2672));
        }
    }
}
