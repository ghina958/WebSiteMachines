using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class addNewFieldsToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubServices");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.AddColumn<string>(
                name: "CategoryImage",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4040f2e-7956-40aa-9037-038acc7c5b18", "AQAAAAIAAYagAAAAENAqdFZt1mg91B+uQ5s4TrlEgnrt4teIls6oB8xqGxOemT4zeEe+beZuIh2+ahuz+Q==", "f014e0af-33ae-4cc5-9456-c2f07cf31cab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cdc25ca-cb82-4b90-8b86-1b547b679aae", "AQAAAAIAAYagAAAAEPgWJS2s0HEPuAyhSxo7NwcyNoKrag6KUf4z6sO23RkOWwTatvgeaAPXI3rwNzWslA==", "c565b55c-2fea-464f-8e50-77a4df480b1e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubServiceImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubServices_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6781e643-f1dc-4a14-922c-ff08bdcff7c3", "AQAAAAIAAYagAAAAEEpPIcGX6VK5yVR/g8PHXOh8EDjtT0QKMxhTY6MaioFoc5bzfPMRcQuQw6Aqdzch0Q==", "69f8631d-fc03-4eff-a04e-22fc02040e85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ee5aebb-4dc0-4eae-9337-fb3e02be8c66", "AQAAAAIAAYagAAAAEFjaclpKDIMsJN1c3P2b5iXnTc889zV16Wx+C+/cNJmr29w7jKG5sg+xmfs7ClKGLQ==", "f017e704-532d-4ad1-ba55-f4cbbb13cf25" });

            migrationBuilder.CreateIndex(
                name: "IX_SubServices_ServiceId",
                table: "SubServices",
                column: "ServiceId");
        }
    }
}
