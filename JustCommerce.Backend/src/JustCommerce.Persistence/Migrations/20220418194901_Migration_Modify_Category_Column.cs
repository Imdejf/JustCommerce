using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Modify_Category_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "CategoryLang",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Category",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "IconPath",
                table: "Category",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "CategoryLang",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Category",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "IconPath",
                table: "Category",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);
        }
    }
}
