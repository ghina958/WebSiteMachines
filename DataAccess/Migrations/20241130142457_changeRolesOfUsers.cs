using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class changeRolesOfUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da8fb90d-ee4a-4f05-a1a6-86df21171960", "AQAAAAIAAYagAAAAECy1Q54Rbwc9T5pPzOzpFZOl8H+15MpinAoRo42pybRb5a5h0jmDTDObcWVkcetZGg==", "8a19949b-7ce8-480b-8458-136db4180a5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25fe34fe-65ae-41c6-b838-c5aa21b13e7d", "AQAAAAIAAYagAAAAENmofJAOeAZLpQwq+f5BUw8j3cAE+aI29FBVxtIFKPEWzW/dcU+n57GtvjB17OpbGg==", "a46a5696-cfa2-4099-815d-18f2010b4c81" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05073594-d0af-4371-a989-fa87da2a9d9e", "AQAAAAIAAYagAAAAELceUwWlQJ1/yavLFdVXBbEnjr/nW7sY258lWT0ZxamK6wtHnlG2sT4QjzlM6Q1FJA==", "aeaa2909-caf8-4982-8ef5-2f416e5bf188" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "030ce18a-2c66-437c-999e-d7545702aced", "AQAAAAIAAYagAAAAELDoyhAIZWvGDfaWMluHvAg/3NCZCuhDIF//K+nlb7tzLxtnhd897iIJtl+4t2pEDw==", "978c1893-18e6-48b6-a650-b8f3ff782735" });
        }
    }
}
