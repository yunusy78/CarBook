using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class reservation_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Transmission",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCars_DropOffLocationId",
                table: "ReservationCars",
                column: "DropOffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCars_PickUpLocationId",
                table: "ReservationCars",
                column: "PickUpLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationCars_Locations_DropOffLocationId",
                table: "ReservationCars",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationCars_Locations_PickUpLocationId",
                table: "ReservationCars",
                column: "PickUpLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationCars_Locations_DropOffLocationId",
                table: "ReservationCars");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationCars_Locations_PickUpLocationId",
                table: "ReservationCars");

            migrationBuilder.DropIndex(
                name: "IX_ReservationCars_DropOffLocationId",
                table: "ReservationCars");

            migrationBuilder.DropIndex(
                name: "IX_ReservationCars_PickUpLocationId",
                table: "ReservationCars");

            migrationBuilder.AlterColumn<int>(
                name: "Transmission",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
