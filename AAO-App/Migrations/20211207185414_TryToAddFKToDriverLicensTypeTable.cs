using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class TryToAddFKToDriverLicensTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicensTypeId",
                table: "DriverLicensTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicensTypes_LicensTypeId",
                table: "DriverLicensTypes",
                column: "LicensTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicensTypes_LicensTypes_LicensTypeId",
                table: "DriverLicensTypes",
                column: "LicensTypeId",
                principalTable: "LicensTypes",
                principalColumn: "LicensTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicensTypes_LicensTypes_LicensTypeId",
                table: "DriverLicensTypes");

            migrationBuilder.DropIndex(
                name: "IX_DriverLicensTypes_LicensTypeId",
                table: "DriverLicensTypes");

            migrationBuilder.DropColumn(
                name: "LicensTypeId",
                table: "DriverLicensTypes");
        }
    }
}
