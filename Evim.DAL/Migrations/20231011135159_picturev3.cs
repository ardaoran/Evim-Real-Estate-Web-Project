using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class picturev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MulkPictures_Mulk_MulkID",
                table: "MulkPictures");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "MulkPictures");

            migrationBuilder.AlterColumn<int>(
                name: "MulkID",
                table: "MulkPictures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 11, 16, 51, 59, 779, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.AddForeignKey(
                name: "FK_MulkPictures_Mulk_MulkID",
                table: "MulkPictures",
                column: "MulkID",
                principalTable: "Mulk",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MulkPictures_Mulk_MulkID",
                table: "MulkPictures");

            migrationBuilder.AlterColumn<int>(
                name: "MulkID",
                table: "MulkPictures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "MulkPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 11, 16, 0, 50, 624, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.AddForeignKey(
                name: "FK_MulkPictures_Mulk_MulkID",
                table: "MulkPictures",
                column: "MulkID",
                principalTable: "Mulk",
                principalColumn: "ID");
        }
    }
}
