using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Fix_In_Attribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ProductAttribute__Store_StoreId",
                table: "_ProductAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageEntity__Store_StoreId",
                table: "LanguageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PredefinedProductAttributeValueEntity__ProductAttribute_ProductAttributeId",
                table: "PredefinedProductAttributeValueEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PredefinedProductAttributeValueLangEntity_LanguageEntity_LanguageId",
                table: "PredefinedProductAttributeValueLangEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PredefinedProductAttributeValueLangEntity_PredefinedProductAttributeValueEntity_PredefinedProductAttributeValueId",
                table: "PredefinedProductAttributeValueLangEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeLangEntity__ProductAttribute_ProductAttributeId",
                table: "ProductAttributeLangEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeLangEntity_LanguageEntity_LanguageId",
                table: "ProductAttributeLangEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStoreEntity__Store_StoreId",
                table: "UserStoreEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeLangEntity",
                table: "ProductAttributeLangEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredefinedProductAttributeValueLangEntity",
                table: "PredefinedProductAttributeValueLangEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredefinedProductAttributeValueEntity",
                table: "PredefinedProductAttributeValueEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LanguageEntity",
                table: "LanguageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Store",
                table: "_Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ProductAttribute",
                table: "_ProductAttribute");

            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.RenameTable(
                name: "ProductAttributeLangEntity",
                newName: "ProductAttributeLang",
                newSchema: "product");

            migrationBuilder.RenameTable(
                name: "PredefinedProductAttributeValueLangEntity",
                newName: "PredefinedProductAttributeValueLang",
                newSchema: "product");

            migrationBuilder.RenameTable(
                name: "PredefinedProductAttributeValueEntity",
                newName: "PredefinedProductAttributeValue",
                newSchema: "product");

            migrationBuilder.RenameTable(
                name: "LanguageEntity",
                newName: "_Language");

            migrationBuilder.RenameTable(
                name: "_Store",
                newName: "Store");

            migrationBuilder.RenameTable(
                name: "_ProductAttribute",
                newName: "ProductAttribute",
                newSchema: "product");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeLangEntity_ProductAttributeId",
                schema: "product",
                table: "ProductAttributeLang",
                newName: "IX_ProductAttributeLang_ProductAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_PredefinedProductAttributeValueLangEntity_LanguageId",
                schema: "product",
                table: "PredefinedProductAttributeValueLang",
                newName: "IX_PredefinedProductAttributeValueLang_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_PredefinedProductAttributeValueEntity_ProductAttributeId",
                schema: "product",
                table: "PredefinedProductAttributeValue",
                newName: "IX_PredefinedProductAttributeValue_ProductAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_PredefinedProductAttributeValueEntity_Id",
                schema: "product",
                table: "PredefinedProductAttributeValue",
                newName: "IX_PredefinedProductAttributeValue_Id");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageEntity_StoreId",
                table: "_Language",
                newName: "IX__Language_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguageEntity_Id",
                table: "_Language",
                newName: "IX__Language_Id");

            migrationBuilder.RenameIndex(
                name: "IX__Store_Id",
                table: "Store",
                newName: "IX_Store_Id");

            migrationBuilder.RenameIndex(
                name: "IX__ProductAttribute_StoreId",
                schema: "product",
                table: "ProductAttribute",
                newName: "IX_ProductAttribute_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX__ProductAttribute_Id",
                schema: "product",
                table: "ProductAttribute",
                newName: "IX_ProductAttribute_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeLang",
                schema: "product",
                table: "ProductAttributeLang",
                columns: new[] { "LanguageId", "ProductAttributeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredefinedProductAttributeValueLang",
                schema: "product",
                table: "PredefinedProductAttributeValueLang",
                columns: new[] { "PredefinedProductAttributeValueId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredefinedProductAttributeValue",
                schema: "product",
                table: "PredefinedProductAttributeValue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Language",
                table: "_Language",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttribute",
                schema: "product",
                table: "ProductAttribute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Language_Store_StoreId",
                table: "_Language",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredefinedProductAttributeValue_ProductAttribute_ProductAttributeId",
                schema: "product",
                table: "PredefinedProductAttributeValue",
                column: "ProductAttributeId",
                principalSchema: "product",
                principalTable: "ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredefinedProductAttributeValueLang__Language_LanguageId",
                schema: "product",
                table: "PredefinedProductAttributeValueLang",
                column: "LanguageId",
                principalTable: "_Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PredefinedProductAttributeValueLang_PredefinedProductAttributeValue_PredefinedProductAttributeValueId",
                schema: "product",
                table: "PredefinedProductAttributeValueLang",
                column: "PredefinedProductAttributeValueId",
                principalSchema: "product",
                principalTable: "PredefinedProductAttributeValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttribute_Store_StoreId",
                schema: "product",
                table: "ProductAttribute",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeLang__Language_LanguageId",
                schema: "product",
                table: "ProductAttributeLang",
                column: "LanguageId",
                principalTable: "_Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeLang_ProductAttribute_ProductAttributeId",
                schema: "product",
                table: "ProductAttributeLang",
                column: "ProductAttributeId",
                principalSchema: "product",
                principalTable: "ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoreEntity_Store_StoreId",
                table: "UserStoreEntity",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Language_Store_StoreId",
                table: "_Language");

            migrationBuilder.DropForeignKey(
                name: "FK_PredefinedProductAttributeValue_ProductAttribute_ProductAttributeId",
                schema: "product",
                table: "PredefinedProductAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_PredefinedProductAttributeValueLang__Language_LanguageId",
                schema: "product",
                table: "PredefinedProductAttributeValueLang");

            migrationBuilder.DropForeignKey(
                name: "FK_PredefinedProductAttributeValueLang_PredefinedProductAttributeValue_PredefinedProductAttributeValueId",
                schema: "product",
                table: "PredefinedProductAttributeValueLang");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttribute_Store_StoreId",
                schema: "product",
                table: "ProductAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeLang__Language_LanguageId",
                schema: "product",
                table: "ProductAttributeLang");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeLang_ProductAttribute_ProductAttributeId",
                schema: "product",
                table: "ProductAttributeLang");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStoreEntity_Store_StoreId",
                table: "UserStoreEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttributeLang",
                schema: "product",
                table: "ProductAttributeLang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttribute",
                schema: "product",
                table: "ProductAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredefinedProductAttributeValueLang",
                schema: "product",
                table: "PredefinedProductAttributeValueLang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredefinedProductAttributeValue",
                schema: "product",
                table: "PredefinedProductAttributeValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Language",
                table: "_Language");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "_Store");

            migrationBuilder.RenameTable(
                name: "ProductAttributeLang",
                schema: "product",
                newName: "ProductAttributeLangEntity");

            migrationBuilder.RenameTable(
                name: "ProductAttribute",
                schema: "product",
                newName: "_ProductAttribute");

            migrationBuilder.RenameTable(
                name: "PredefinedProductAttributeValueLang",
                schema: "product",
                newName: "PredefinedProductAttributeValueLangEntity");

            migrationBuilder.RenameTable(
                name: "PredefinedProductAttributeValue",
                schema: "product",
                newName: "PredefinedProductAttributeValueEntity");

            migrationBuilder.RenameTable(
                name: "_Language",
                newName: "LanguageEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Store_Id",
                table: "_Store",
                newName: "IX__Store_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttributeLang_ProductAttributeId",
                table: "ProductAttributeLangEntity",
                newName: "IX_ProductAttributeLangEntity_ProductAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttribute_StoreId",
                table: "_ProductAttribute",
                newName: "IX__ProductAttribute_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAttribute_Id",
                table: "_ProductAttribute",
                newName: "IX__ProductAttribute_Id");

            migrationBuilder.RenameIndex(
                name: "IX_PredefinedProductAttributeValueLang_LanguageId",
                table: "PredefinedProductAttributeValueLangEntity",
                newName: "IX_PredefinedProductAttributeValueLangEntity_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_PredefinedProductAttributeValue_ProductAttributeId",
                table: "PredefinedProductAttributeValueEntity",
                newName: "IX_PredefinedProductAttributeValueEntity_ProductAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_PredefinedProductAttributeValue_Id",
                table: "PredefinedProductAttributeValueEntity",
                newName: "IX_PredefinedProductAttributeValueEntity_Id");

            migrationBuilder.RenameIndex(
                name: "IX__Language_StoreId",
                table: "LanguageEntity",
                newName: "IX_LanguageEntity_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX__Language_Id",
                table: "LanguageEntity",
                newName: "IX_LanguageEntity_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Store",
                table: "_Store",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttributeLangEntity",
                table: "ProductAttributeLangEntity",
                columns: new[] { "LanguageId", "ProductAttributeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__ProductAttribute",
                table: "_ProductAttribute",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredefinedProductAttributeValueLangEntity",
                table: "PredefinedProductAttributeValueLangEntity",
                columns: new[] { "PredefinedProductAttributeValueId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredefinedProductAttributeValueEntity",
                table: "PredefinedProductAttributeValueEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LanguageEntity",
                table: "LanguageEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductAttribute__Store_StoreId",
                table: "_ProductAttribute",
                column: "StoreId",
                principalTable: "_Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageEntity__Store_StoreId",
                table: "LanguageEntity",
                column: "StoreId",
                principalTable: "_Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredefinedProductAttributeValueEntity__ProductAttribute_ProductAttributeId",
                table: "PredefinedProductAttributeValueEntity",
                column: "ProductAttributeId",
                principalTable: "_ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredefinedProductAttributeValueLangEntity_LanguageEntity_LanguageId",
                table: "PredefinedProductAttributeValueLangEntity",
                column: "LanguageId",
                principalTable: "LanguageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PredefinedProductAttributeValueLangEntity_PredefinedProductAttributeValueEntity_PredefinedProductAttributeValueId",
                table: "PredefinedProductAttributeValueLangEntity",
                column: "PredefinedProductAttributeValueId",
                principalTable: "PredefinedProductAttributeValueEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeLangEntity__ProductAttribute_ProductAttributeId",
                table: "ProductAttributeLangEntity",
                column: "ProductAttributeId",
                principalTable: "_ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeLangEntity_LanguageEntity_LanguageId",
                table: "ProductAttributeLangEntity",
                column: "LanguageId",
                principalTable: "LanguageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStoreEntity__Store_StoreId",
                table: "UserStoreEntity",
                column: "StoreId",
                principalTable: "_Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
