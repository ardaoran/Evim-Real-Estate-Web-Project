using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class slidev6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Slide",
                newName: "Picture2");

            migrationBuilder.AddColumn<string>(
                name: "Picture1",
                table: "Slide",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 10, 21, 7, 57, 36, DateTimeKind.Local).AddTicks(2604));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture1",
                table: "Slide");

            migrationBuilder.RenameColumn(
                name: "Picture2",
                table: "Slide",
                newName: "Picture");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 10, 20, 54, 19, 55, DateTimeKind.Local).AddTicks(7138));
        }
    }
}
