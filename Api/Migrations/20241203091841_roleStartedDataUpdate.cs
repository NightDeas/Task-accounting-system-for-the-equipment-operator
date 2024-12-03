using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class roleStartedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01d72217-bb22-4dd2-ac45-d68107e5a570"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("abb30232-f844-4e5d-b7b5-06a79e91d857"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("70b10473-a669-4f20-b0b5-a917c300a8b4"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("e2690d33-8916-4419-94a2-507cc888381f"), null, "Operator", "OPERATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70b10473-a669-4f20-b0b5-a917c300a8b4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2690d33-8916-4419-94a2-507cc888381f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01d72217-bb22-4dd2-ac45-d68107e5a570"), null, "Operator", null },
                    { new Guid("abb30232-f844-4e5d-b7b5-06a79e91d857"), null, "Administrator", null }
                });
        }
    }
}
