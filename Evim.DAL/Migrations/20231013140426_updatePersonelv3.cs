using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatePersonelv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonelID",
                table: "ProductPictures",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 13, 17, 4, 26, 111, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_PersonelID",
                table: "ProductPictures",
                column: "PersonelID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictures_Personel_PersonelID",
                table: "ProductPictures",
                column: "PersonelID",
                principalTable: "Personel",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictures_Personel_PersonelID",
                table: "ProductPictures");

            migrationBuilder.DropIndex(
                name: "IX_ProductPictures_PersonelID",
                table: "ProductPictures");

            migrationBuilder.DropColumn(
                name: "PersonelID",
                table: "ProductPictures");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 13, 17, 2, 12, 269, DateTimeKind.Local).AddTicks(1252));
        }
    }
}
