using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mulkekleupdatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mulkEkle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adres = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Metrekare = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    YatakOdasi = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Banyo = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Durum = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Tur = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mulkEkle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mulkEkle_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 15, 0, 9, 5, 276, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.CreateIndex(
                name: "IX_mulkEkle_CategoryID",
                table: "mulkEkle",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mulkEkle");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 15, 0, 1, 49, 906, DateTimeKind.Local).AddTicks(94));
        }
    }
}
