using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Id_To_Category_Lang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryLang",
                table: "SubCategoryLang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryLang",
                table: "CategoryLang");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SubCategoryLang",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CategoryLang",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryLang",
                table: "SubCategoryLang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryLang",
                table: "CategoryLang",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryLang_SubCategoryId",
                table: "SubCategoryLang",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLang_CategoryId",
                table: "CategoryLang",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryLang",
                table: "SubCategoryLang");

            migrationBuilder.DropIndex(
                name: "IX_SubCategoryLang_SubCategoryId",
                table: "SubCategoryLang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryLang",
                table: "CategoryLang");

            migrationBuilder.DropIndex(
                name: "IX_CategoryLang_CategoryId",
                table: "CategoryLang");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubCategoryLang");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryLang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryLang",
                table: "SubCategoryLang",
                columns: new[] { "SubCategoryId", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryLang",
                table: "CategoryLang",
                columns: new[] { "CategoryId", "Name" });
        }
    }
}
