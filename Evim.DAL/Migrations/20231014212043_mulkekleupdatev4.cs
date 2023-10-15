using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mulkekleupdatev4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "mulkEkle",
                newName: "TelNumber");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "mulkEkle",
                type: "Varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MulkName",
                table: "mulkEkle",
                type: "Varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "mulkEkle",
                type: "Varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 15, 0, 20, 43, 298, DateTimeKind.Local).AddTicks(7187));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "mulkEkle");

            migrationBuilder.DropColumn(
                name: "MulkName",
                table: "mulkEkle");

            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "mulkEkle");

            migrationBuilder.RenameColumn(
                name: "TelNumber",
                table: "mulkEkle",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 15, 0, 9, 5, 276, DateTimeKind.Local).AddTicks(5270));
        }
    }
}
