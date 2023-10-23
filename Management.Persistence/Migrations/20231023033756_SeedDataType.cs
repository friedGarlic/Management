using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DbDataType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 10, 23, 11, 37, 55, 918, DateTimeKind.Local).AddTicks(7773), new DateTime(2023, 10, 23, 11, 37, 55, 918, DateTimeKind.Local).AddTicks(7783), "", "SickLeave" },
                    { 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 23, 11, 37, 55, 918, DateTimeKind.Local).AddTicks(7785), "", "Vacation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DbDataType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DbDataType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
