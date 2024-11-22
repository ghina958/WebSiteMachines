using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class changedTheDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5d64847-ff84-4db6-b4a1-e9b11c0abf38", "AQAAAAIAAYagAAAAEEssam1hfQjNjAlifOjeppakrx1CIKoREV5c91Lr3Ad9603WnvVh8VCMENqwrs+BrA==", "081061f8-ec5e-4763-95d6-b7d9a031194a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "0b8cf453-4d4e-43db-b1bd-a64e4c8ee5e5", "ahmet@gmail.com", true, "ahmet", false, null, "AHMET@GMAIL.COM", "AHMET2000", null, "+905050364355", true, "40d122e3-1ca6-49da-94a3-0769894b0e0b", false, "ahmet2000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d57eccb2-4712-43fe-8a6a-fb80806c99cb", "AQAAAAIAAYagAAAAEF6QLX0Vt75upkAXw5qFFMgS8D7xgbuWLPycUl8kxnr1UUaZyoRcmPy+jWHXnB9WjQ==", "0C05BD0D-B52E-4735-822A-DCD22C17798C" });
        }
    }
}
