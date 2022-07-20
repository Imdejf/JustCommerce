using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class AddedCascadeRemoveToCheckoutAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutAttributeValueLang_CheckoutAttributeValue_CheckoutAttributeValueId",
                schema: "attribute",
                table: "CheckoutAttributeValueLang");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutAttributeValueLang_CheckoutAttributeValue_CheckoutAttributeValueId",
                schema: "attribute",
                table: "CheckoutAttributeValueLang",
                column: "CheckoutAttributeValueId",
                principalSchema: "attribute",
                principalTable: "CheckoutAttributeValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutAttributeValueLang_CheckoutAttributeValue_CheckoutAttributeValueId",
                schema: "attribute",
                table: "CheckoutAttributeValueLang");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutAttributeValueLang_CheckoutAttributeValue_CheckoutAttributeValueId",
                schema: "attribute",
                table: "CheckoutAttributeValueLang",
                column: "CheckoutAttributeValueId",
                principalSchema: "attribute",
                principalTable: "CheckoutAttributeValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
