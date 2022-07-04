using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Fix_String_LanguageId_To_Guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsoCode",
                table: "ProductTypePropertyLang");

            migrationBuilder.DropColumn(
                name: "IsoCode",
                table: "ProductLang");

            migrationBuilder.DropColumn(
                name: "IsoCode",
                table: "CategoryLang");

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "ProductTypePropertyLang",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "ProductLang",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "CategoryLang",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypePropertyLang_LanguageId",
                table: "ProductTypePropertyLang",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLang_LanguageId",
                table: "ProductLang",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLang_LanguageId",
                table: "CategoryLang",
                column: "LanguageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLang_Language_LanguageId",
                table: "CategoryLang",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLang_Language_LanguageId",
                table: "ProductLang",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypePropertyLang_Language_LanguageId",
                table: "ProductTypePropertyLang",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLang_Language_LanguageId",
                table: "CategoryLang");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLang_Language_LanguageId",
                table: "ProductLang");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypePropertyLang_Language_LanguageId",
                table: "ProductTypePropertyLang");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypePropertyLang_LanguageId",
                table: "ProductTypePropertyLang");

            migrationBuilder.DropIndex(
                name: "IX_ProductLang_LanguageId",
                table: "ProductLang");

            migrationBuilder.DropIndex(
                name: "IX_CategoryLang_LanguageId",
                table: "CategoryLang");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProductTypePropertyLang");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProductLang");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CategoryLang");

            migrationBuilder.AddColumn<string>(
                name: "IsoCode",
                table: "ProductTypePropertyLang",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsoCode",
                table: "ProductLang",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsoCode",
                table: "CategoryLang",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }
    }
}
