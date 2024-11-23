using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class DeletedFieldsOfSenMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ContactInfo");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "ContactInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ContactInfo",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2aabc02f-059f-4451-8baa-9165416c0b00", "AQAAAAIAAYagAAAAEMjFPq/1Xly6Y+ZTIq03LwsQvKTYPCMV6Uhh00fIekfUt4etp/NoZoHcoYLgcm6mCw==", "3798844c-343d-46f1-8bfe-bd2b75c08ed7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "052fafe2-d6bd-44ae-ba1a-323aa7d7faac", "AQAAAAIAAYagAAAAEC1poqrcG4JKRwzRbbFEG1BQczTlRCOzeySGk/qr5NqobhssUoJH5r16+tR/F2u2AA==", "c7ada6c6-891f-4931-942b-a54f0de93550" });
        }
    }
}
