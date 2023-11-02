using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Manufacturer = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    FlightHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlightDestinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, defaultValue: 15m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDestinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightDestinations_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Id", "FlightHours", "Manufacturer", "Model", "Year" },
                values: new object[,]
                {
                    { 1, 1688, "Stehr - Emmerich", "Cruze", 1982 },
                    { 2, 1650, "Satterfield, Hagenes and ", "Alpine", 2006 },
                    { 3, 151, "Hammes - Feil", "Alpine", 1978 },
                    { 4, 1388, "Schroeder Inc", "Escalade", 1970 },
                    { 5, 239, "Nikolaus Group", "Wrangler", 1998 },
                    { 6, 132, "Terry, Turner and Schmitt", "Taurus", 1996 },
                    { 7, 1542, "Greenfelder - Zieme", "Land Cruiser", 1974 },
                    { 8, 1228, "O'Kon Group", "Camry", 2017 },
                    { 9, 1887, "Marquardt Group", "Element", 2019 },
                    { 10, 991, "Rau Inc", "Malibu", 1989 }
                });

            migrationBuilder.InsertData(
                table: "FlightDestinations",
                columns: new[] { "Id", "AircraftId", "Start", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 9, 7, 10, 37, 4, 953, DateTimeKind.Local).AddTicks(8702), 55.360310068471840m },
                    { 2, 3, new DateTime(2023, 7, 18, 23, 42, 28, 483, DateTimeKind.Local).AddTicks(2082), 191.495747836056160m },
                    { 3, 1, new DateTime(2023, 10, 21, 0, 33, 31, 512, DateTimeKind.Local).AddTicks(1837), 216.289991043976840m },
                    { 4, 10, new DateTime(2023, 7, 20, 15, 19, 4, 0, DateTimeKind.Local).AddTicks(3391), 376.483626162988360m },
                    { 5, 1, new DateTime(2023, 7, 21, 8, 36, 9, 361, DateTimeKind.Local).AddTicks(6254), 114.355516865629510m },
                    { 6, 3, new DateTime(2023, 9, 17, 15, 10, 13, 690, DateTimeKind.Local).AddTicks(5780), 62.388356628746710m },
                    { 7, 7, new DateTime(2023, 10, 12, 7, 21, 50, 494, DateTimeKind.Local).AddTicks(2280), 247.970267016316120m },
                    { 8, 1, new DateTime(2023, 7, 24, 8, 5, 38, 600, DateTimeKind.Local).AddTicks(8796), 311.874024882048580m },
                    { 9, 8, new DateTime(2023, 8, 29, 4, 29, 49, 71, DateTimeKind.Local).AddTicks(6200), 376.041178505421640m },
                    { 10, 9, new DateTime(2023, 8, 26, 3, 18, 58, 956, DateTimeKind.Local).AddTicks(1850), 304.874977411121380m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightDestinations_AircraftId",
                table: "FlightDestinations",
                column: "AircraftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightDestinations");

            migrationBuilder.DropTable(
                name: "Aircrafts");
        }
    }
}
