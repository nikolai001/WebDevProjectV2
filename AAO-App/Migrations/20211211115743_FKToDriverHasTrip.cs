using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class FKToDriverHasTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "DriverHasTrips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DriverHasTrips_TripId",
                table: "DriverHasTrips",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverHasTrips_Trips_TripId",
                table: "DriverHasTrips",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverHasTrips_Trips_TripId",
                table: "DriverHasTrips");

            migrationBuilder.DropIndex(
                name: "IX_DriverHasTrips_TripId",
                table: "DriverHasTrips");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "DriverHasTrips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
