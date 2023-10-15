using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MulkCategoryPictureAddv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    ParentCategoryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryID",
                        column: x => x.ParentCategoryID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Mulk",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MulkAdi = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adres = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Metrekare = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    YatakOdasi = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Banyo = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
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
                    Name = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Picture = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    MulkID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MulkPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MulkPictures_Mulk_MulkID",
                        column: x => x.MulkID,
                        principalTable: "Mulk",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 11, 15, 18, 17, 302, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryID",
                table: "Category",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Mulk_CategoryID",
                table: "Mulk",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MulkPictures_MulkID",
                table: "MulkPictures",
                column: "MulkID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MulkPictures");

            migrationBuilder.DropTable(
                name: "Mulk");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 10, 21, 30, 28, 554, DateTimeKind.Local).AddTicks(7000));
        }
    }
}
