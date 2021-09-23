using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneDirectory.WebApi.Migrations
{
    public partial class migration_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Company", "Name", "Surname" },
                values: new object[] { 1, "ABC", "Joey", "Wayne" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Company", "Name", "Surname" },
                values: new object[] { 2, "DEF", "Uma", "Rabbit" });

            migrationBuilder.InsertData(
                table: "ContactInfos",
                columns: new[] { "ContactInfoID", "InfoContent", "InfoType", "UserID" },
                values: new object[,]
                {
                    { 1, "1234567890", 0, 1 },
                    { 2, "joey@email.com", 1, 1 },
                    { 3, "1234567890", 0, 2 },
                    { 4, "Rome", 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "ContactInfoID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "ContactInfoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "ContactInfoID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "ContactInfoID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);
        }
    }
}
