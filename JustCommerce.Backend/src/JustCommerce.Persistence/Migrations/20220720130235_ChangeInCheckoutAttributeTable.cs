using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class ChangeInCheckoutAttributeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutAttribute_TaxCategory_TaxCategoryId",
                schema: "attribute",
                table: "CheckoutAttribute");

            migrationBuilder.DropIndex(
                name: "IX_CheckoutAttribute_ConditionAttributeId",
                schema: "attribute",
                table: "CheckoutAttribute");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaxCategoryId",
                schema: "attribute",
                table: "CheckoutAttribute",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConditionAttributeId",
                schema: "attribute",
                table: "CheckoutAttribute",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttribute_ConditionAttributeId",
                schema: "attribute",
                table: "CheckoutAttribute",
                column: "ConditionAttributeId",
                unique: true,
                filter: "[ConditionAttributeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutAttribute_TaxCategory_TaxCategoryId",
                schema: "attribute",
                table: "CheckoutAttribute",
                column: "TaxCategoryId",
                principalSchema: "tax",
                principalTable: "TaxCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutAttribute_TaxCategory_TaxCategoryId",
                schema: "attribute",
                table: "CheckoutAttribute");

            migrationBuilder.DropIndex(
                name: "IX_CheckoutAttribute_ConditionAttributeId",
                schema: "attribute",
                table: "CheckoutAttribute");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaxCategoryId",
                schema: "attribute",
                table: "CheckoutAttribute",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConditionAttributeId",
                schema: "attribute",
                table: "CheckoutAttribute",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutAttribute_ConditionAttributeId",
                schema: "attribute",
                table: "CheckoutAttribute",
                column: "ConditionAttributeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutAttribute_TaxCategory_TaxCategoryId",
                schema: "attribute",
                table: "CheckoutAttribute",
                column: "TaxCategoryId",
                principalSchema: "tax",
                principalTable: "TaxCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
