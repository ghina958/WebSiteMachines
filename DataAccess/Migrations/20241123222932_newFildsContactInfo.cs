using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class newFildsContactInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ContactInfo",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MailUs",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "ContactInfo",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "ContactInfo",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "MailUs",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c5d9972-bebf-4bb6-89dc-591e6782c3a6", "AQAAAAIAAYagAAAAEB3i27KE4YEblPUwJiGFHFlQtUq31JeMb/nZhIfR2Dl2M2MeyZEMJjt2AZg1BS8uOA==", "c3f8ef5b-51cf-41c2-bbad-ad4c6f362e02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed8f1475-c517-4975-9698-05caf7562c71", "AQAAAAIAAYagAAAAEO2zKl/UJ2jJI8I7PoKTftAl3F/Fzi9PJe3m7L3O/cwfmoKnUuf+0terbZbFuTNhtA==", "fad38059-190f-4c74-8f1a-18884f233c62" });
        }
    }
}
