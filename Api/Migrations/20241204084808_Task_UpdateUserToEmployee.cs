using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Task_UpdateUserToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("70b10473-a669-4f20-b0b5-a917c300a8b4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2690d33-8916-4419-94a2-507cc888381f"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1ac1a8bb-7f8f-4423-abfc-51e16501f097"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("8161ae14-fdad-4ccf-980b-3a5e6b108240"), null, "Operator", "OPERATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ac1a8bb-7f8f-4423-abfc-51e16501f097"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8161ae14-fdad-4ccf-980b-3a5e6b108240"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("70b10473-a669-4f20-b0b5-a917c300a8b4"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("e2690d33-8916-4419-94a2-507cc888381f"), null, "Operator", "OPERATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
