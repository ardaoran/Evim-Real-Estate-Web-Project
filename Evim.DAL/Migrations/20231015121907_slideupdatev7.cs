using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class slideupdatev7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Slide",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 15, 15, 19, 7, 612, DateTimeKind.Local).AddTicks(415));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Slide");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 15, 15, 1, 18, 975, DateTimeKind.Local).AddTicks(9820));
        }
    }
}
