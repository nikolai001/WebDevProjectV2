using Microsoft.EntityFrameworkCore.Migrations;

namespace AAO_App.Migrations
{
    public partial class TryToFixDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
