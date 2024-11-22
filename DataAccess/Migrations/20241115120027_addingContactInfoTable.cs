using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class addingContactInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WorkingHours = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobileNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileNumber_ContactInfo_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "ContactInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c811e23-bc2b-4878-a6eb-87ef5e45dc87", "AQAAAAIAAYagAAAAEA1kGXzk6fJbh5zkEfsMizGytZc5qoJcdFl27nYY+gubGOs8ZWDqGnz91WhFxxPqzA==", "31edb779-c874-44e0-8808-9536b40d29aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aefb5628-585a-4c43-b5e6-ea613a97a035", "AQAAAAIAAYagAAAAEJsqEu3XIYVSBCH0q7MznJKbOtjPKBcJhyJGqsSwv2RcerFMt4MHrkmRWQVfjPuQKA==", "e7466472-2ec6-4d2c-abce-059f66a62afc" });

            migrationBuilder.CreateIndex(
                name: "IX_MobileNumber_ContactInfoId",
                table: "MobileNumber",
                column: "ContactInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileNumber");

            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed65ba3-b9be-4be8-9e81-f45cbe6021ae", "AQAAAAIAAYagAAAAECz2IaJo6SCmprIdFkMJ+6dhQFX2lLl21kbzm9iMrw70rHceyLKg/I/VCzZVD+dMmw==", "532066ac-413b-4d23-a099-2f2fa99d42f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f35e9e7-0990-4f19-ba4a-d5d8885279c8", "AQAAAAIAAYagAAAAEHCdLFx7qX9SYvGbdLFKus5jbt9zm+14dXMc8B0To9P8at7ThgPgs15YWBwkchvxbw==", "caaf9c0b-a1fc-477a-ac8a-a0af19324d30" });
        }
    }
}
