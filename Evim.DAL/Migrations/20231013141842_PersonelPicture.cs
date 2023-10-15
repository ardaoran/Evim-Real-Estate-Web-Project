using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PersonelPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PersonelPictures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Picture = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonelPictures_Personel_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "Personel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 13, 17, 18, 41, 898, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.CreateIndex(
                name: "IX_PersonelPictures_PersonelID",
                table: "PersonelPictures",
                column: "PersonelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelPictures");

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
    }
}
