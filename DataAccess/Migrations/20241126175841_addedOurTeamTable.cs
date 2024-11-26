using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class addedOurTeamTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalImagePaths",
                table: "AboutUs");

            migrationBuilder.AddColumn<string>(
                name: "SliderImage",
                table: "ContactInfo",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OurTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurTeam", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurTeam");

            migrationBuilder.DropColumn(
                name: "SliderImage",
                table: "ContactInfo");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalImagePaths",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
