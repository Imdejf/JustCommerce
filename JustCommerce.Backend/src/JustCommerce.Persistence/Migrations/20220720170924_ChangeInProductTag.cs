using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class ChangeInProductTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "product",
                table: "ProductTagLang");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "product",
                table: "ProductTagLang");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "product",
                table: "ProductTag",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "product",
                table: "ProductTag",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "product",
                table: "ProductTag");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "product",
                table: "ProductTag");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "product",
                table: "ProductTagLang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "product",
                table: "ProductTagLang",
                type: "datetime2",
                nullable: true);
        }
    }
}
