using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class TryToFixDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Employees_EmployeeId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_EmployeeId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Trips");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EmployeeId",
                table: "Trips",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Employees_EmployeeId",
                table: "Trips",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
