using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SlidePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlidePictures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: false),
                    Picture = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    SlideID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlidePictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SlidePictures_Slide_SlideID",
                        column: x => x.SlideID,
                        principalTable: "Slide",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 15, 13, 35, 26, 658, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.CreateIndex(
                name: "IX_SlidePictures_SlideID",
                table: "SlidePictures",
                column: "SlideID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlidePictures");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLongDate",
                value: new DateTime(2023, 10, 15, 0, 20, 43, 298, DateTimeKind.Local).AddTicks(7187));
        }
    }
}
