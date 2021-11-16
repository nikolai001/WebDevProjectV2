using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class AddFKToAvailabilites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_DriverId",
                table: "Availabilities",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Drivers_DriverId",
                table: "Availabilities",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "DriverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Drivers_DriverId",
                table: "Availabilities");

            migrationBuilder.DropIndex(
                name: "IX_Availabilities_DriverId",
                table: "Availabilities");
        }
    }
}
