using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class productguncellemev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "Product",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tur",
                table: "Product",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 13, 1, 14, 44, 56, DateTimeKind.Local).AddTicks(4281));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Tur",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 13, 0, 11, 59, 780, DateTimeKind.Local).AddTicks(6786));
        }
    }
}
