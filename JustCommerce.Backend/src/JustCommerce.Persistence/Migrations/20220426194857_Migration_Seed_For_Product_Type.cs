using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Seed_For_Product_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name", "ShopId" },
                values: new object[,]
                {
                    { new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"), null, new DateTime(2022, 4, 26, 21, 48, 53, 134, DateTimeKind.Local).AddTicks(785), null, null, "Regały", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1") },
                    { new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"), null, new DateTime(2022, 4, 26, 21, 48, 53, 134, DateTimeKind.Local).AddTicks(719), null, null, "Pojemniki", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1") },
                    { new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"), null, new DateTime(2022, 4, 26, 21, 48, 53, 134, DateTimeKind.Local).AddTicks(789), null, null, "Maty", new Guid("83e84e94-b1ee-4cbf-be40-daea69347600") },
                    { new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"), null, new DateTime(2022, 4, 26, 21, 48, 53, 134, DateTimeKind.Local).AddTicks(793), null, null, "Drzwi", new Guid("83e84e94-b1ee-4cbf-be40-daea69347600") }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("371b379b-3ff4-4523-bd15-b545e185b97c"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8539176a-3578-48e1-a2d7-3cce1389c762"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("d13b4109-2acd-46f5-bd8b-d7f789fac0e0"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e8d5076f-7501-4bb7-8581-f7f894d7a879"));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 39, 8, 3, DateTimeKind.Local).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("83e84e94-b1ee-4cbf-be40-daea69347600"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 39, 8, 3, DateTimeKind.Local).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 39, 7, 961, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "_Language",
                keyColumn: "Id",
                keyValue: new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"),
                column: "CreatedDate",
                value: new DateTime(2022, 4, 26, 21, 39, 7, 957, DateTimeKind.Local).AddTicks(2546));
        }
    }
}
