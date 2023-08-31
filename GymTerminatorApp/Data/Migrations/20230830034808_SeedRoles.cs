using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTerminatorApp.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "147d6c3d-3a08-4356-ae59-1412a279497f", "4837a24f-4653-4fd8-a3e3-bcfe13370af3", "Entrenador", "ENTRENADOR" },
                    { "5d0af95c-1862-431c-abb3-56aa0bf217bb", "f9e44443-d18d-403d-9dcf-2a3d119838f4", "Cliente", "CLIENTE" },
                    { "6d452aa3-e611-4cf1-82d9-f866101bd60e", "df4c8274-74e4-4b9f-b6b1-bb1dd7476068", "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9231ca89-c9b4-4e78-914c-5d5f4639a99d", 0, "d0b6726d-8b23-4cae-937b-1e588e7730c5", "ApplicationUser", "martinezjohnny324@gmail.com", true, false, null, "MARTINEZJOHNNY324@GMAIL.COM", "MARTINEZJOHNNY324@GMAIL.COM", "AQAAAAEAACcQAAAAEMaedDKDRDBUeaXqm8x63jFlI7Huvaa20QVgnpDoJZqckEYfzMmYpMrTXfB5yPCsuQ==", null, false, "bf56b1c7-a725-46c1-b158-fa9e11873a52", false, "martinezjohnny324@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6d452aa3-e611-4cf1-82d9-f866101bd60e", "9231ca89-c9b4-4e78-914c-5d5f4639a99d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "147d6c3d-3a08-4356-ae59-1412a279497f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d0af95c-1862-431c-abb3-56aa0bf217bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d452aa3-e611-4cf1-82d9-f866101bd60e", "9231ca89-c9b4-4e78-914c-5d5f4639a99d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d452aa3-e611-4cf1-82d9-f866101bd60e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9231ca89-c9b4-4e78-914c-5d5f4639a99d");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
