using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class updateAdditionalImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87c93e22-cbb9-495b-b783-9e2ce7c1e8a2", "AQAAAAIAAYagAAAAEJCJCwHtD/BIhMuZXe76nrt/s7Swa3JfOqC8HtoLHukLxQfCs3/Uj15PO74YGgBYbA==", "8c6a6f05-ec5f-4d98-8979-a2b8a7c1ae8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62700a96-f8ed-4889-8518-aa39c8d1852c", "AQAAAAIAAYagAAAAEDybx7i++IWqt70/BvWG01byoduHK88TzD6EET9CI4RVaZnrNnZL6T73BjO9SXmHnw==", "3dfc854d-ca1e-4f80-aceb-89424314fad8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "345dc1cc-bbd4-41c9-9c88-56a50f564c0f", "AQAAAAIAAYagAAAAEHfTkChpNlOzUUDMcVzxgOOQ1562Xq22ZdZsVvp6/g18JBB6qEIhzNMBLDYQ7254CQ==", "fd37312c-4536-4209-9ebb-cc989028cfc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b690850a-4142-4c6f-bc1e-50902dcff4f9", "AQAAAAIAAYagAAAAECWka6ACd0xqsDNIObzPgNyEKsFVa6Fck6bqyvKAWfHqWdQS3LhmL5zosrN0HAfMQg==", "6d422a14-1139-48bc-8a9c-d4d08d3ea9da" });
        }
    }
}
