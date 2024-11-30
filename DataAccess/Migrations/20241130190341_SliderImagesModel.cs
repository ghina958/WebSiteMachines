using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class SliderImagesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SliderImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "179dabe9-0761-4dbc-9a37-67f0f8e38fba", "AQAAAAIAAYagAAAAEAHUIliyCRrsyRugkUdTJLvX8f5kGr/rxkDzg0XlqgtYF39D5w9nXyiKiylzIclGeA==", "491faf7e-999f-4751-b8ce-a641880fef83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b36047dc-0407-4a69-8ac3-fec8092be420", "AQAAAAIAAYagAAAAEOtwbcZnUbs2O/TPJwweivPNJywqlYsmxZTI8RvSs/AKs/BFZaWCpwFtDD3s1OmpRA==", "1972114c-0e6e-4918-8591-3fa26a0d005f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderImages");

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
    }
}
