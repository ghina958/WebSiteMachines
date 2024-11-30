using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class teestingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "CA5E4BB1-5245-42DE-A631-6AF6B58E3CBD", "Admin", "Administrator" },
                    { 2, "50262EC3-A41E-47E5-BA7B-A04CB03062E5", "User", "User" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71b37e97-0f05-48c6-adcc-aabf83fe74f7", "AQAAAAIAAYagAAAAEJVOEE6uCioN6uTTBmxAzcScTBQYz+R3sWA2WRQV2qbSSzXnlEByLPMHpqkst0YUfQ==", "d338bdeb-67be-410f-8555-0e93c1847a5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37217a02-056b-4424-a5f6-0656a2da8ab6", "AQAAAAIAAYagAAAAENIL7OpWxe83AhbxyzadsMAsHY3E8G+qftSNUaCzsajnnDsCGOVTD0IHn1ZhXXcgmg==", "d699b84d-8dc7-4c8d-8c6b-53a7b8fb2387" });
        }
    }
}
