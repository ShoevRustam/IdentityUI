using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityUI.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2646f93d-7657-4495-820c-3a5450b1e2b6", "d4d71de6-a69d-4372-ac8b-7c37f1ab572a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "507a55bb-b20e-4cdb-bae3-7461462d3955", "fa1d519a-2818-40b4-b122-ca2a78ab49a4" });
        }
    }
}
