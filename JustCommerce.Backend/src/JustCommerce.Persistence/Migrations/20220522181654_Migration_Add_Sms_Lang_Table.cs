using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCommerce.Persistence.Migrations
{
    public partial class Migration_Add_Sms_Lang_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmsTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SmsAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SmsType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsTemplate_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmsTemplate_SmsAccount_SmsAccountId",
                        column: x => x.SmsAccountId,
                        principalTable: "SmsAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SmsTemplateLang",
                columns: table => new
                {
                    SmsTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsTemplateLang", x => new { x.SmsTemplateId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_SmsTemplateLang_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmsTemplateLang_SmsTemplate_SmsTemplateId",
                        column: x => x.SmsTemplateId,
                        principalTable: "SmsTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SmsTemplate",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name", "ShopId", "SmsAccountId", "SmsType" },
                values: new object[,]
                {
                    { new Guid("027aa12d-b89d-4993-b4f3-aa15135ebfbc"), true, null, null, null, null, "OrderCancelled", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"), new Guid("2bbfc7c9-8c9c-4f53-82ef-f7560a463070"), "OrderCancelled" },
                    { new Guid("2a4bdbb1-c4e5-4b5f-b8f0-36369d2560b1"), true, null, null, null, null, "OrderPlaced", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"), new Guid("2bbfc7c9-8c9c-4f53-82ef-f7560a463070"), "OrderPlaced" },
                    { new Guid("c2514d93-4e4e-4e27-bf9d-d0a77db3629b"), true, null, null, null, null, "OrderSend", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"), new Guid("2bbfc7c9-8c9c-4f53-82ef-f7560a463070"), "OrderSend" },
                    { new Guid("fd60132b-a9a8-4fea-8e71-0a8eea2e62e3"), true, null, null, null, null, "OrderInProgress", new Guid("6cef7328-534d-4699-98af-8779fba7d3a1"), new Guid("2bbfc7c9-8c9c-4f53-82ef-f7560a463070"), "OrderInProgress" }
                });

            migrationBuilder.InsertData(
                table: "SmsTemplateLang",
                columns: new[] { "LanguageId", "SmsTemplateId", "Text" },
                values: new object[,]
                {
                    { new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"), new Guid("027aa12d-b89d-4993-b4f3-aa15135ebfbc"), "OrderCancelled EN" },
                    { new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"), new Guid("027aa12d-b89d-4993-b4f3-aa15135ebfbc"), "OrderCancelled PL" },
                    { new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"), new Guid("2a4bdbb1-c4e5-4b5f-b8f0-36369d2560b1"), "OrderPlaced EN" },
                    { new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"), new Guid("2a4bdbb1-c4e5-4b5f-b8f0-36369d2560b1"), "OrderPlaced PL" },
                    { new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"), new Guid("c2514d93-4e4e-4e27-bf9d-d0a77db3629b"), "OrderSend EN" },
                    { new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"), new Guid("c2514d93-4e4e-4e27-bf9d-d0a77db3629b"), "OrderSend PL" },
                    { new Guid("87f0f759-323f-477d-886a-0afd7272ccd9"), new Guid("fd60132b-a9a8-4fea-8e71-0a8eea2e62e3"), "OrderInProgress EN" },
                    { new Guid("b80fe531-4bb7-4f2d-a69e-86d8e20602e9"), new Guid("fd60132b-a9a8-4fea-8e71-0a8eea2e62e3"), "OrderInProgress PL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmsTemplate_Id",
                table: "SmsTemplate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SmsTemplate_ShopId",
                table: "SmsTemplate",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsTemplate_SmsAccountId",
                table: "SmsTemplate",
                column: "SmsAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsTemplateLang_LanguageId",
                table: "SmsTemplateLang",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmsTemplateLang");

            migrationBuilder.DropTable(
                name: "SmsTemplate");
        }
    }
}
