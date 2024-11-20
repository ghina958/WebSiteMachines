using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class addedTheHashPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5d64847-ff84-4db6-b4a1-e9b11c0abf38", "AQAAAAIAAYagAAAAEEssam1hfQjNjAlifOjeppakrx1CIKoREV5c91Lr3Ad9603WnvVh8VCMENqwrs+BrA==", "081061f8-ec5e-4763-95d6-b7d9a031194a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b8cf453-4d4e-43db-b1bd-a64e4c8ee5e5", null, "40d122e3-1ca6-49da-94a3-0769894b0e0b" });
        }
    }
}
