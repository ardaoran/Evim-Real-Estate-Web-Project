using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adminpanelv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "LastLoginIP", "LastLongDate", "NameSurname", "Password", "UserName" },
                values: new object[] { 1, "", new DateTime(2023, 10, 6, 18, 28, 16, 324, DateTimeKind.Local).AddTicks(1096), "Arda Oran", "202cb962ac59075b964b07152d234b70", "arda" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
