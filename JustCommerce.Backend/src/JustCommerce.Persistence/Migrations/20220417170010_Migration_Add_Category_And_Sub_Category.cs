using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Category_And_Sub_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Slug = table.Column<string>(type: "varchar", nullable: false),
                    OrderValue = table.Column<int>(type: "int", nullable: false),
                    IconPath = table.Column<string>(type: "varchar", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLang",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false),
                    Keywords = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    Content = table.Column<string>(type: "varchar", nullable: false),
                    IsoCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLang", x => new { x.CategoryId, x.Name });
                    table.ForeignKey(
                        name: "FK_CategoryLang_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Slug = table.Column<string>(type: "varchar", nullable: false),
                    OrderValue = table.Column<int>(type: "int", nullable: false),
                    IconPath = table.Column<string>(type: "varchar", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryLang",
                columns: table => new
                {
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false),
                    Keywords = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    Content = table.Column<string>(type: "varchar", nullable: false),
                    IsoCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryLang", x => new { x.SubCategoryId, x.Name });
                    table.ForeignKey(
                        name: "FK_SubCategoryLang_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryLang");

            migrationBuilder.DropTable(
                name: "SubCategoryLang");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
