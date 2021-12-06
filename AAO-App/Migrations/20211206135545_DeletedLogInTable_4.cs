using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class DeletedLogInTable_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_DriverLicensTypes_DriverLicensTypesDriverLicensTypeId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_DriverLicensTypesDriverLicensTypeId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverLicensTypesDriverLicensTypeId",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "DriverLicensType",
                table: "Drivers",
                newName: "DriverLicensTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_DriverLicensTypeId",
                table: "Drivers",
                column: "DriverLicensTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_DriverLicensTypes_DriverLicensTypeId",
                table: "Drivers",
                column: "DriverLicensTypeId",
                principalTable: "DriverLicensTypes",
                principalColumn: "DriverLicensTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_DriverLicensTypes_DriverLicensTypeId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_DriverLicensTypeId",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "DriverLicensTypeId",
                table: "Drivers",
                newName: "DriverLicensType");

            migrationBuilder.AddColumn<int>(
                name: "DriverLicensTypesDriverLicensTypeId",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_DriverLicensTypesDriverLicensTypeId",
                table: "Drivers",
                column: "DriverLicensTypesDriverLicensTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_DriverLicensTypes_DriverLicensTypesDriverLicensTypeId",
                table: "Drivers",
                column: "DriverLicensTypesDriverLicensTypeId",
                principalTable: "DriverLicensTypes",
                principalColumn: "DriverLicensTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
