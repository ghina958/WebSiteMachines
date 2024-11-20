using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class hashPasswordSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEF6QLX0Vt75upkAXw5qFFMgS8D7xgbuWLPycUl8kxnr1UUaZyoRcmPy+jWHXnB9WjQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { null, "AQAAAAEAACcQAAAAEDC+kHjBcJSgZp1iPzWyIC9OEzt7+G+iylt+93YHF0fiHP4oVoXdeCVAbfWuZk24Vg==" });
        }
    }
}
