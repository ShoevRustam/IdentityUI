using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityUI.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "899d718f-20c3-4ef6-a8ec-6be6aa26f79c", true, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFEDPO+nAqtaO0L4rBAl/+9MufuwlOMXhpqKqZ53+HtNQeccbWkd1g8iVIaj7b29bg==", "987654321", "90771840-887f-401a-9af7-a262a2f9b055" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "2646f93d-7657-4495-820c-3a5450b1e2b6", false, null, null, null, "1234567890", "d4d71de6-a69d-4372-ac8b-7c37f1ab572a" });
        }
    }
}
