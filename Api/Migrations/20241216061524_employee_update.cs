using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class employee_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ae7ba5c-69ca-440c-a570-ccfb1db4366e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7937d807-45cc-4541-be03-ea20c8c2e4a1"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("b764c14c-b11f-4854-b396-bfdb0e444a05"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c1918635-bc33-4976-bcc5-d88d2e4a2adf"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("cb1ea232-98b8-414c-a1a4-f6ef35f8c416"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("54919d6b-f338-475e-b647-5cc938f3a72d"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("cea356e0-a279-4103-a91b-edf191f0644b"), null, "Operator", "OPERATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("54919d6b-f338-475e-b647-5cc938f3a72d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cea356e0-a279-4103-a91b-edf191f0644b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1ae7ba5c-69ca-440c-a570-ccfb1db4366e"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("7937d807-45cc-4541-be03-ea20c8c2e4a1"), null, "Operator", "OPERATOR" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Created", "DeadLine", "Description", "EmployeeId", "IsCompleted" },
                values: new object[,]
                {
                    { new Guid("b764c14c-b11f-4854-b396-bfdb0e444a05"), new DateTime(2024, 12, 9, 11, 53, 38, 106, DateTimeKind.Local).AddTicks(2781), new DateTime(2024, 12, 19, 11, 53, 38, 106, DateTimeKind.Local).AddTicks(2782), "Description", new Guid("d37a3aef-1a7e-4f88-9350-01a434f5d444"), false },
                    { new Guid("c1918635-bc33-4976-bcc5-d88d2e4a2adf"), new DateTime(2024, 12, 9, 11, 53, 38, 106, DateTimeKind.Local).AddTicks(2804), new DateTime(2024, 12, 23, 11, 53, 38, 106, DateTimeKind.Local).AddTicks(2805), "Description 2", new Guid("d37a3aef-1a7e-4f88-9350-01a434f5d444"), false },
                    { new Guid("cb1ea232-98b8-414c-a1a4-f6ef35f8c416"), new DateTime(2024, 12, 9, 11, 53, 38, 106, DateTimeKind.Local).AddTicks(2809), new DateTime(2024, 12, 10, 11, 53, 38, 106, DateTimeKind.Local).AddTicks(2810), "Description 3", new Guid("d37a3aef-1a7e-4f88-9350-01a434f5d444"), false }
                });
        }
    }
}
