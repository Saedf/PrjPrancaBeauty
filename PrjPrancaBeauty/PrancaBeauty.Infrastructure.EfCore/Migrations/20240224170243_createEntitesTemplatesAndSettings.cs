using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class createEntitesTemplatesAndSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d85e60a-d12a-4452-b387-b12000eb756d"));

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    SiteTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiteDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sitemail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SitePhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsInManufacture = table.Column<bool>(type: "bit", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setting_Language_LangId",
                        column: x => x.LangId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("7ed70eda-81e8-4822-97ea-b120015293b5"), "df133f0f-003d-4ae3-9e00-21f457d66e03", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Setting_LangId",
                table: "Setting",
                column: "LangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ed70eda-81e8-4822-97ea-b120015293b5"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("7d85e60a-d12a-4452-b387-b12000eb756d"), "ba90812e-8222-407f-8d43-285d6f5cc144", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });
        }
    }
}
