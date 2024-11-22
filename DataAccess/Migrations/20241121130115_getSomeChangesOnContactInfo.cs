using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteMachines.Migrations
{
    /// <inheritdoc />
    public partial class getSomeChangesOnContactInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileNumber");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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
                values: new object[] { "3c5d9972-bebf-4bb6-89dc-591e6782c3a6", "AQAAAAIAAYagAAAAEB3i27KE4YEblPUwJiGFHFlQtUq31JeMb/nZhIfR2Dl2M2MeyZEMJjt2AZg1BS8uOA==", "c3f8ef5b-51cf-41c2-bbad-ad4c6f362e02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed8f1475-c517-4975-9698-05caf7562c71", "AQAAAAIAAYagAAAAEO2zKl/UJ2jJI8I7PoKTftAl3F/Fzi9PJe3m7L3O/cwfmoKnUuf+0terbZbFuTNhtA==", "fad38059-190f-4c74-8f1a-18884f233c62" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ContactInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ContactInfo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingHours",
                table: "ContactInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MobileNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactInfoId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileNumber_ContactInfo_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "ContactInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MobileNumber_ContactInfoId",
                table: "MobileNumber",
                column: "ContactInfoId");
        }
    }
}
