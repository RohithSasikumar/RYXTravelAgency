using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RYXTravelAgency.Server.Data.Migrations
{
    public partial class AddDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Arrivals",
                columns: new[] { "Id", "Arriv_Location", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "South Island, New Zealand", "System", new DateTime(2022, 2, 1, 13, 46, 46, 767, DateTimeKind.Local).AddTicks(186), new DateTime(2022, 2, 1, 13, 46, 46, 767, DateTimeKind.Local).AddTicks(206), "System" },
                    { 2, "Rome", "System", new DateTime(2022, 2, 1, 13, 46, 46, 767, DateTimeKind.Local).AddTicks(209), new DateTime(2022, 2, 1, 13, 46, 46, 767, DateTimeKind.Local).AddTicks(211), "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "83cc2e0c-8948-4286-9d45-d878dc174f7e", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "cfca44f5-0309-43fc-a374-515998fc7215", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "83f982be-9b77-4225-a3db-4d50126f03e9", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEMbfCX9zCPu3Sbe6lKmGNtf7NtNKSaX8BUvTEY17VRwSIXVYdNAHf/XnEEDE7XCaGQ==", null, false, "5b80dbb5-0483-470a-b4a8-dbcc2dbe5321", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Departures",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Depart_Location", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 2, 1, 13, 46, 46, 767, DateTimeKind.Local).AddTicks(3085), new DateTime(2022, 2, 1, 13, 46, 46, 767, DateTimeKind.Local).AddTicks(3092), "Singapore", "System" },
                    { 2, "System", new DateTime(2022, 2, 1, 13, 46, 46, 767, DateTimeKind.Local).AddTicks(3095), new DateTime(2022, 2, 1, 13, 46, 46, 767, DateTimeKind.Local).AddTicks(3096), "Bangkok, Thailand", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 2, 1, 13, 46, 46, 764, DateTimeKind.Local).AddTicks(6544), new DateTime(2022, 2, 1, 13, 46, 46, 765, DateTimeKind.Local).AddTicks(6853), "Boeing 439-10", "System" },
                    { 2, "System", new DateTime(2022, 2, 1, 13, 46, 46, 765, DateTimeKind.Local).AddTicks(7721), new DateTime(2022, 2, 1, 13, 46, 46, 765, DateTimeKind.Local).AddTicks(7727), "Airbus D123 WEX", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Arrivals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Arrivals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Departures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
