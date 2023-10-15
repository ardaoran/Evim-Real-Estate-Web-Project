using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MulktoUrun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MulkPictures");

            migrationBuilder.DropTable(
                name: "Mulk");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adres = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Metrekare = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    YatakOdasi = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Banyo = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Picture = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductPictures_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 12, 1, 43, 29, 436, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_ProductID",
                table: "ProductPictures",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Mulk",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    Adres = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Banyo = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Metrekare = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    MulkAdi = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    YatakOdasi = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mulk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mulk_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MulkPictures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MulkID = table.Column<int>(type: "int", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Picture = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MulkPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MulkPictures_Mulk_MulkID",
                        column: x => x.MulkID,
                        principalTable: "Mulk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 11, 17, 27, 13, 2, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.CreateIndex(
                name: "IX_Mulk_CategoryID",
                table: "Mulk",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MulkPictures_MulkID",
                table: "MulkPictures",
                column: "MulkID");
        }
    }
}
