using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Delete_FK_From_Lang_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypePropertyLang",
                table: "ProductTypePropertyLang");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ProductTypePropertyLang",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypePropertyLang",
                table: "ProductTypePropertyLang",
                columns: new[] { "ProductTypePropertyId", "Name", "Value" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypePropertyLang",
                table: "ProductTypePropertyLang");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ProductTypePropertyLang",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypePropertyLang",
                table: "ProductTypePropertyLang",
                column: "ProductTypePropertyId");
        }
    }
}
