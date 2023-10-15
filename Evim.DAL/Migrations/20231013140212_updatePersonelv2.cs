using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatePersonelv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 13, 17, 2, 12, 269, DateTimeKind.Local).AddTicks(1252));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 13, 16, 45, 28, 403, DateTimeKind.Local).AddTicks(1358));
        }
    }
}
