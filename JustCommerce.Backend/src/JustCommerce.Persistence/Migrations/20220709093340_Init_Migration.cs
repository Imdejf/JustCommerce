using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Init_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Store",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SslEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Hosts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyVat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectedShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FtpPhotoFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterSource = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Theme = table.Column<int>(type: "int", nullable: false),
                    Profile = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_ProductAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductAttribute__Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "_Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOrginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameInternational = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultLanguage = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageEntity__Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "_Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissionEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionDomainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionFlagValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissionEntity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStoreEntity",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoreEntity", x => new { x.StoreId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserStoreEntity__Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "_Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStoreEntity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredefinedProductAttributeValueEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceAdjustmentUsePercentage = table.Column<bool>(type: "bit", nullable: false),
                    WeightAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPreSelected = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedProductAttributeValueEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredefinedProductAttributeValueEntity__ProductAttribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "_ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeLangEntity",
                columns: table => new
                {
                    ProductAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeLangEntity", x => new { x.LanguageId, x.ProductAttributeId });
                    table.ForeignKey(
                        name: "FK_ProductAttributeLangEntity__ProductAttribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "_ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeLangEntity_LanguageEntity_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredefinedProductAttributeValueLangEntity",
                columns: table => new
                {
                    PredefinedProductAttributeValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedProductAttributeValueLangEntity", x => new { x.PredefinedProductAttributeValueId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PredefinedProductAttributeValueLangEntity_LanguageEntity_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredefinedProductAttributeValueLangEntity_PredefinedProductAttributeValueEntity_PredefinedProductAttributeValueId",
                        column: x => x.PredefinedProductAttributeValueId,
                        principalTable: "PredefinedProductAttributeValueEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__ProductAttribute_Id",
                table: "_ProductAttribute",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX__ProductAttribute_StoreId",
                table: "_ProductAttribute",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX__Store_Id",
                table: "_Store",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_Id",
                table: "LanguageEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_StoreId",
                table: "LanguageEntity",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PredefinedProductAttributeValueEntity_Id",
                table: "PredefinedProductAttributeValueEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PredefinedProductAttributeValueEntity_ProductAttributeId",
                table: "PredefinedProductAttributeValueEntity",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_PredefinedProductAttributeValueLangEntity_LanguageId",
                table: "PredefinedProductAttributeValueLangEntity",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeLangEntity_ProductAttributeId",
                table: "ProductAttributeLangEntity",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionEntity_Id",
                table: "UserPermissionEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionEntity_UserId",
                table: "UserPermissionEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoreEntity_UserId",
                table: "UserStoreEntity",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredefinedProductAttributeValueLangEntity");

            migrationBuilder.DropTable(
                name: "ProductAttributeLangEntity");

            migrationBuilder.DropTable(
                name: "UserPermissionEntity");

            migrationBuilder.DropTable(
                name: "UserStoreEntity");

            migrationBuilder.DropTable(
                name: "PredefinedProductAttributeValueEntity");

            migrationBuilder.DropTable(
                name: "LanguageEntity");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "_ProductAttribute");

            migrationBuilder.DropTable(
                name: "_Store");
        }
    }
}
