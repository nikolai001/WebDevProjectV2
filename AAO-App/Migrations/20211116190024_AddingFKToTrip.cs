using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class AddingFKToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
     
            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesEmpId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageContents",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TripInfo",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EmployeesEmpId",
                table: "Trips",
                column: "EmployeesEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Employees_EmployeesEmpId",
                table: "Trips",
                column: "EmployeesEmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
