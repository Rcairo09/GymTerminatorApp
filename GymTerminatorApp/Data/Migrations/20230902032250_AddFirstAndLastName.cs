using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTerminatorApp.Data.Migrations
{
    public partial class AddFirstAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c087e17e-a071-4611-b5ad-ee1d796e62da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d87d6079-4d75-49c2-98a3-25983db8da7d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e20eb199-1d42-4f38-b22a-a786960ca6d1", "f6aedddd-d247-4982-841a-a7515ea0cd67" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e20eb199-1d42-4f38-b22a-a786960ca6d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6aedddd-d247-4982-841a-a7515ea0cd67");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30235231-41ae-48bd-8b91-8977ef8dc513", "59cd0b2d-c7e1-4e36-b8c2-ee12f3cf7871", "Administrador", "ADMINISTRADOR" },
                    { "ca1b2b66-54ae-4df3-a29f-2476371889d3", "095c469f-30ec-42d0-827f-3701e4a3c19c", "Cliente", "CLIENTE" },
                    { "d4a78eab-5206-4662-b1dd-bdcdf184c48d", "db809782-f546-4a0f-8a54-6e9f50c7e58b", "Entrenador", "ENTRENADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5c8705c6-2082-4942-982a-20abe6808f9a", 0, "91ffd25d-c90b-44a4-baec-0e44cad23bf8", "ApplicationUser", "martinezjohnny324@gmail.com", true, "Johnny", "Eduardo", false, null, "MARTINEZJOHNNY324@GMAIL.COM", "MARTINEZJOHNNY324@GMAIL.COM", "AQAAAAEAACcQAAAAEM8ZuWxdrGx4a+E1xcpv1t7HAkE/KCsUZ21JlYMPJSJVwGr/7KbH1ruqcghn5qnI6w==", null, false, "b3c3c485-4dbf-47d2-8324-041c6aac5130", false, "martinezjohnny324@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "30235231-41ae-48bd-8b91-8977ef8dc513", "5c8705c6-2082-4942-982a-20abe6808f9a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca1b2b66-54ae-4df3-a29f-2476371889d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4a78eab-5206-4662-b1dd-bdcdf184c48d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "30235231-41ae-48bd-8b91-8977ef8dc513", "5c8705c6-2082-4942-982a-20abe6808f9a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30235231-41ae-48bd-8b91-8977ef8dc513");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c8705c6-2082-4942-982a-20abe6808f9a");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c087e17e-a071-4611-b5ad-ee1d796e62da", "f005fa0c-09c7-410f-a587-59b228023559", "Entrenador", "ENTRENADOR" },
                    { "d87d6079-4d75-49c2-98a3-25983db8da7d", "e43b250b-5abf-46de-b249-a1601d52a534", "Cliente", "CLIENTE" },
                    { "e20eb199-1d42-4f38-b22a-a786960ca6d1", "05200dcb-bf61-4863-a0ac-d960bbfe8cc9", "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f6aedddd-d247-4982-841a-a7515ea0cd67", 0, "b4664696-20d7-4729-921c-4ff83be5c7d1", "ApplicationUser", "martinezjohnny324@gmail.com", true, false, null, "MARTINEZJOHNNY324@GMAIL.COM", "MARTINEZJOHNNY324@GMAIL.COM", "AQAAAAEAACcQAAAAENQf4r7e423YesEb0OkNC9DFOEBvfqyp9zPCahCs/4QnBxIioQ6HtNVgQs6T2rVxJQ==", null, false, "2324add9-dfd9-4565-8a72-931fd941359c", false, "martinezjohnny324@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e20eb199-1d42-4f38-b22a-a786960ca6d1", "f6aedddd-d247-4982-841a-a7515ea0cd67" });
        }
    }
}
