using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Ingore_Column_To_User_Permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "identity",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "identity",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "identity",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "identity",
                table: "UserPermission");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "identity",
                table: "User",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "identity",
                table: "UserPermission",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "identity",
                table: "UserPermission",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                schema: "identity",
                table: "UserPermission",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "identity",
                table: "UserPermission",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "identity",
                table: "User",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
