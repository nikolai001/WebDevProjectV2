using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class UpdatedEmpTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Employees_EmployeesEmpId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_EmployeesEmpId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "EmployeesEmpId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Trips",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "DepartmentHasEmployees",
                columns: table => new
                {
                    DepartmentHasEmployeesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepId = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDepId = table.Column<int>(type: "int", nullable: true),
                    EmppId = table.Column<int>(type: "int", nullable: false),
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentHasEmployees", x => x.DepartmentHasEmployeesId);
                    table.ForeignKey(
                        name: "FK_DepartmentHasEmployees_Departments_DepartmentsDepId",
                        column: x => x.DepartmentsDepId,
                        principalTable: "Departments",
                        principalColumn: "DepId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentHasEmployees_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EmployeeId",
                table: "Trips",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentHasEmployees_DepartmentsDepId",
                table: "DepartmentHasEmployees",
                column: "DepartmentsDepId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentHasEmployees_EmployeesEmployeeId",
                table: "DepartmentHasEmployees",
                column: "EmployeesEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Employees_EmployeeId",
                table: "Trips",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Employees_EmployeeId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "DepartmentHasEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Trips_EmployeeId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Trips",
                newName: "EmpId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmpId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesEmpId",
                table: "Trips",
                type: "int",
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
