using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class UpdateDepHasEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentHasEmployees_Employees_EmployeesEmployeeId",
                table: "DepartmentHasEmployees");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentHasEmployees_EmployeesEmployeeId",
                table: "DepartmentHasEmployees");

            migrationBuilder.DropColumn(
                name: "EmployeesEmployeeId",
                table: "DepartmentHasEmployees");

            migrationBuilder.RenameColumn(
                name: "EmppId",
                table: "DepartmentHasEmployees",
                newName: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentHasEmployees_EmployeeId",
                table: "DepartmentHasEmployees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentHasEmployees_Employees_EmployeeId",
                table: "DepartmentHasEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentHasEmployees_Employees_EmployeeId",
                table: "DepartmentHasEmployees");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentHasEmployees_EmployeeId",
                table: "DepartmentHasEmployees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "DepartmentHasEmployees",
                newName: "EmppId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesEmployeeId",
                table: "DepartmentHasEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentHasEmployees_EmployeesEmployeeId",
                table: "DepartmentHasEmployees",
                column: "EmployeesEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentHasEmployees_Employees_EmployeesEmployeeId",
                table: "DepartmentHasEmployees",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
